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
    public class AtendimentoService : ICRUDService<ConsultOutputDTO, ConsultInputDTO>
    {
        private readonly ICRUDRepository<Consult> _repository;
        private readonly ICRUDRepository<Paciente> _pacienteRepository;
        private readonly IMapper _mapper;
        private readonly IEnviarEmail _enviarEmail;

        public AtendimentoService(ICRUDRepository<Consult> repository, ICRUDRepository<Paciente> pacienteRepository, IMapper mapper, IEnviarEmail enviarEmail)
        {
            _repository = repository;
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
            _enviarEmail = enviarEmail;
        }

        public async Task<ConsultOutputDTO> BuscarPorId(int id)
        {
            Consult atendimentoDb = await _repository.BuscarPorId(id);
            ConsultOutputDTO AtendimentoMap = _mapper.Map<ConsultOutputDTO>(atendimentoDb);
            return AtendimentoMap;
        }

        public async Task<List<ConsultOutputDTO>> BuscarPorTexto(string termoPesquisa)
        {
            List<Consult> atendimentoDb = await _repository.BuscarPorTexto(termoPesquisa);
            List<ConsultOutputDTO> atendimentoMap = _mapper.Map<List<ConsultOutputDTO>>(atendimentoDb);
            return atendimentoMap;
        }

        public async Task<List<ConsultOutputDTO>> BuscarTodos()
        {
            List<Consult> atendimentoDb = await _repository.BuscarTodos();
            List<ConsultOutputDTO> atendimentoMap = _mapper.Map<List<ConsultOutputDTO>>(atendimentoDb);
            return atendimentoMap;

        }

        public async Task<ConsultOutputDTO> Cadastrar(ConsultInputDTO cadastrar)
        {
            Consult atendimentoCadastro = _mapper.Map<Consult>(cadastrar);
            Consult atendimentoDb = await _repository.Cadastrar(atendimentoCadastro);
            ConsultOutputDTO atendimentoMap = _mapper.Map<ConsultOutputDTO>(atendimentoDb);
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

        public async Task<ConsultOutputDTO> Editar(int id, ConsultInputDTO editar)
        {
            Consult buscarDb = await _repository.BuscarPorId(id);
            if (buscarDb == null)
            {
                throw new Exception("Atendimento não localizado");
            }

            Consult atendimentoEditar = _mapper.Map<Consult>(editar);
            atendimentoEditar.Id = id;
            Consult atendimentoDb = await _repository.Editar(atendimentoEditar);
            ConsultOutputDTO atendimentoMap = _mapper.Map<ConsultOutputDTO>(atendimentoDb);
            return atendimentoMap;
        }
    }
}
