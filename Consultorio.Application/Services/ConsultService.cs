using AutoMapper;
using Consultorio.Application.Calendario;
using Consultorio.Application.Email;
using Consultorio.Application.Interface;
using Consultorio.Domain.Entity;
using Consultorio.Domain.Entity.Email;
using Consultorio.Domain.Entity.InputDTOs;
using Consultorio.Domain.Entity.OutPutDTOs;
using Consultorio.Infra.Data.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Consultorio.Application.Service
{
    public class ConsultService : ICRUDService<ConsultOutputDTO, ConsultInputDTO>
    {
        private readonly IConfiguration _configuration;
        private readonly ICRUDRepository<Consult> _repository;
        private readonly ICRUDRepository<Patient> _patientRepository;
        private readonly IMapper _mapper;
        private readonly ISeedEmail _enviarEmail;
        private readonly ICRUDRepository<EmailEntity> _emailRepository;
        private readonly IGoogleCalendarService _googleCalendarServico;

        public ConsultService(IConfiguration configuration, ICRUDRepository<Consult> repository, ICRUDRepository<Patient> patientRepository, IMapper mapper, ISeedEmail enviarEmail, ICRUDRepository<EmailEntity> emailRepository, IGoogleCalendarService googleCalendarServico)
        {
            _configuration = configuration;
            _repository = repository;
            _patientRepository = patientRepository;
            _mapper = mapper;
            _enviarEmail = enviarEmail;
            _emailRepository = emailRepository;
            _googleCalendarServico = googleCalendarServico;
        }

        public async Task<ConsultOutputDTO> FindById(int id)
        {
            Consult consultDb = await _repository.FindById(id);
            ConsultOutputDTO consultMap = _mapper.Map<ConsultOutputDTO>(consultDb);
            return consultMap;
        }

        public async Task<List<ConsultOutputDTO>> FindByText(string query)
        {
            List<Consult> consultDb = await _repository.FindByText(query);
            List<ConsultOutputDTO> consultMap = _mapper.Map<List<ConsultOutputDTO>>(consultDb);
            return consultMap;
        }

        public async Task<List<ConsultOutputDTO>> GetAll()
        {
            List<Consult> consultDb = await _repository.GetAll();
            List<ConsultOutputDTO> consultMap = _mapper.Map<List<ConsultOutputDTO>>(consultDb);
            return consultMap;

        }

        public async Task<ConsultOutputDTO> Create(ConsultInputDTO create)
        {
            //Create
            Consult consultCreate = _mapper.Map<Consult>(create);
            Consult consultDb = await _repository.Create(consultCreate);
            
            //Find
            var consultDb_Include = await _repository.FindById(consultDb.Id);

            //Seed E-mail
            var emailDb = await _emailRepository.FindById(1);
            var emailSubject = emailDb.Title
                .Replace("{{1}}", consultDb_Include.Service.Name);
            var emailBody = emailDb.Body
                .Replace("{{1}}", consultDb_Include.Patient.Name)
                .Replace("{{2}}", consultDb_Include.Start.Date.ToString("dd/MM/yyyy"))
                .Replace("{{3}}", consultDb_Include.Start.ToString("HH:mm")) ;

            var resultado = await _enviarEmail.Seed(consultDb_Include.Patient.Email, emailSubject, emailBody);

            //Send Schedule
            var schedule = await _googleCalendarServico.CreateGoogleCalendar(
                new GoogleCalendar { 
                    Summary= $"Consulta: {consultDb_Include.Service.Name}", 
                    Description= "", 
                    Location= "Rua dos Bobos, Nº 0, Teresina,PI", 
                    Start= consultDb_Include.Start, 
                    End = consultDb_Include.End}, 
                consultDb_Include.Patient.Email);

            consultDb_Include.IdentifiedGoogleCalendar = schedule.Id;
            var consultAddCalendar = await _repository.Update(consultDb_Include);

            //Retorn
            ConsultOutputDTO consultMap = _mapper.Map<ConsultOutputDTO>(consultAddCalendar);

            return consultMap;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var consultToDelete = await _repository.FindById(id);
                if (consultToDelete is null)
                {
                    throw new Exception("Consulta informada não existe ou já foi deletado");
                }
                var result = await _repository.Delete(id);
                if (result is true)
                {
                    await _googleCalendarServico.DeleteEventGoogleCalendar(consultToDelete.IdentifiedGoogleCalendar);
                }
                return result;
            }
            catch (Exception msg)
            {
                throw new Exception(msg.Message);
            }            
        }

        public async Task<ConsultOutputDTO> Update(int id, ConsultInputDTO update)
        {
            Consult buscarDb = await _repository.FindById(id);
            if (buscarDb == null)
            {
                throw new Exception("Atendimento não localizado");
            }         
            
            Consult consultEditar = _mapper.Map<Consult>(update);
            consultEditar.Id = id;
            consultEditar.IdentifiedGoogleCalendar = buscarDb.IdentifiedGoogleCalendar;
            Consult consultDb = await _repository.Update(consultEditar);

            //Find
            var consultDb_Include = await _repository.FindById(consultDb.Id);
            //Seed E-mail
            var resultado = await _enviarEmail.Seed(
                consultDb_Include.Patient.Email,
                $"Confirmação de Alteração de Agendamento de consulta: {consultDb_Include.Service.Name}.",
                $"Prezado(a), {consultDb_Include.Patient.Name} <br> " +
                $"É com satisfação que informamos que a sua consulta do dia {buscarDb.Start.Date.ToString("dd/MM/yyyy")} às {buscarDb.Start.ToString("HH:mm")}, foi alterada para o dia {consultDb_Include.Start.Date.ToString("dd/MM/yyyy")} às {consultDb_Include.Start.ToString("HH:mm")} .<br> " +
                $"A consulta será realizada em nosso consultório localizado na Rua dos Bobos, Nº 0 <br> " +
                $"Pedimos que chegue com pelo menos 15 minutos de antecedência para que possamos realizar o seu atendimento de forma pontual. Caso haja qualquer impedimento ou necessidade de reagendamento, pedimos a gentileza de entrar em contato conosco o mais breve possível.<br>" +
                $"Estamos à disposição para esclarecer qualquer dúvida que possa surgir. Agradecemos pela confiança em nossos serviços e estamos ansiosos para atendê-lo(a) em breve.<br> <br>" +
                $"Atenciosamente, <br>" +
                $"Clínica Médica <br>" +
                $"(86) 9 9011-2255"
                );

            var consultUpdate = await _googleCalendarServico.UpdateEventGoogleCalendar(buscarDb.IdentifiedGoogleCalendar, $"Consulta: {consultDb_Include.Service.Name}", consultDb_Include.Start, consultDb_Include.End);
            ConsultOutputDTO consultMap = _mapper.Map<ConsultOutputDTO>(consultDb);

            return consultMap;
        }
    }
}
