using AutoMapper;
using Consultorio.Application.Calendario;
using Consultorio.Application.Email;
using Consultorio.Application.Interface;
using Consultorio.Domain.Entity;
using Consultorio.Domain.Entity.InputDTOs;
using Consultorio.Domain.Entity.OutPutDTOs;
using Consultorio.Infra.Data.Interfaces;

namespace Consultorio.Application.Service
{
    public class AtendimentoService : ICRUDService<AtendimentoOutputDTO, AtendimentoInputDTO>
    {
        private readonly ICRUDRepository<Atendimento> _repository;
        private readonly ICRUDRepository<Paciente> _pacienteRepository;
        private readonly IMapper _mapper;
        private readonly IEnviarEmail _enviarEmail;

        public AtendimentoService(ICRUDRepository<Atendimento> repository, ICRUDRepository<Paciente> pacienteRepository, IMapper mapper, IEnviarEmail enviarEmail)
        {
            _repository = repository;
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
            _enviarEmail = enviarEmail;
        }

        public async Task<AtendimentoOutputDTO> BuscarPorId(int id)
        {
            Atendimento atendimentoDb = await _repository.BuscarPorId(id);
            AtendimentoOutputDTO AtendimentoMap = _mapper.Map<AtendimentoOutputDTO>(atendimentoDb);
            return AtendimentoMap;
        }

        public async Task<List<AtendimentoOutputDTO>> BuscarPorTexto(string termoPesquisa)
        {
            List<Atendimento> atendimentoDb = await _repository.BuscarPorTexto(termoPesquisa);
            List<AtendimentoOutputDTO> atendimentoMap = _mapper.Map<List<AtendimentoOutputDTO>>(atendimentoDb);
            return atendimentoMap;
        }

        public async Task<List<AtendimentoOutputDTO>> BuscarTodos()
        {
            List<Atendimento> atendimentoDb = await _repository.BuscarTodos();
            List<AtendimentoOutputDTO> atendimentoMap = _mapper.Map<List<AtendimentoOutputDTO>>(atendimentoDb);
            return atendimentoMap;

        }

        public async Task<AtendimentoOutputDTO> Cadastrar(AtendimentoInputDTO cadastrar)
        {
            Atendimento atendimentoCadastro = _mapper.Map<Atendimento>(cadastrar);
            Atendimento atendimentoDb = await _repository.Cadastrar(atendimentoCadastro);
            AtendimentoOutputDTO atendimentoMap = _mapper.Map<AtendimentoOutputDTO>(atendimentoDb);
            var atendimentoDb_Include = await _repository.BuscarPorId(atendimentoMap.Id);
            var resultado = await _enviarEmail.Enviar(
                atendimentoDb_Include.Paciente.Email,
                $"Confirmação de Agendamento de consulta: {atendimentoDb_Include.Servico.Nome}.",
                $"Prezado(a), {atendimentoDb_Include.Paciente.Nome} <br> " +
                $"É com satisfação que informamos a confirmação do agendamento da sua consulta para o dia {atendimentoDb_Include.Inicio.Date.ToString("dd/MM/yyyy")} às {atendimentoDb_Include.Inicio.ToString("HH:mm")}.<br> " +
                $"A consulta será realizada em nosso consultório localizado na Rua dos Bobos, Nº 0 <br> " +
                $"Pedimos que chegue com pelo menos 15 minutos de antecedência para que possamos realizar o seu atendimento de forma pontual. Caso haja qualquer impedimento ou necessidade de reagendamento, pedimos a gentileza de entrar em contato conosco o mais breve possível.<br>" +
                $"Estamos à disposição para esclarecer qualquer dúvida que possa surgir. Agradecemos pela confiança em nossos serviços e estamos ansiosos para atendê-lo(a) em breve.<br> <br>" +
                $"Atenciosamente, <br>" +
                $"Clínica Médica <br>" +
                $"(86) 9 9011-2255"
                );
            var agendamento = await GoogleCalendarServico.CreateGoogleCalendar(
                new GoogleCalendar { 
                    Summary= $"Consulta: {atendimentoDb_Include.Servico.Nome}", 
                    Description= "", 
                    Location= "Rua dos Bobos, Nº 0, Teresina,PI", 
                    Start= atendimentoDb_Include.Inicio, 
                    End = atendimentoDb_Include.Fim}, 
                atendimentoDb_Include.Paciente.Email);



            return null;
           // return atendimentoMap;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _repository.Delete(id);
            if (result is true)
            {
                await GoogleCalendarServico.DeleteEventGoogleCalendar("5r7h01fdlo5d7i8n4lkbnhk7d8");
            }
            return result;
        }

        public async Task<AtendimentoOutputDTO> Editar(int id, AtendimentoInputDTO editar)
        {
            Atendimento buscarDb = await _repository.BuscarPorId(id);
            if (buscarDb == null)
            {
                throw new Exception("Atendimento não localizado");
            }

            Atendimento atendimentoEditar = _mapper.Map<Atendimento>(editar);
            atendimentoEditar.Id = id;
            Atendimento atendimentoDb = await _repository.Editar(atendimentoEditar);
            AtendimentoOutputDTO atendimentoMap = _mapper.Map<AtendimentoOutputDTO>(atendimentoDb);
            return atendimentoMap;
        }
    }
}
