using AutoMapper;
using Consultorio.Application.Interface;
using Consultorio.Domain.Entity.Email;
using Consultorio.Domain.Entity.InputDTOs;
using Consultorio.Domain.Entity.OutPutDTOs;
using Consultorio.Infra.Data.Interfaces;

namespace Consultorio.Application.Services
{
    public class EmailService : ICRUDService<EmailOutputDTO, EmailInputDTO>
    {
        private readonly ICRUDRepository<EmailEntity> _repository;
        private readonly IMapper _mapper;

        public EmailService(ICRUDRepository<EmailEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EmailOutputDTO> FindById(int id)
        {
            EmailEntity emailDb = await _repository.FindById(id);
            EmailOutputDTO emailMap = _mapper.Map<EmailOutputDTO>(emailDb);
            return emailMap;
        }

        public async Task<List<EmailOutputDTO>> FindByText(string query)
        {
            List<EmailEntity> emailDb = await _repository.FindByText(query);
            List<EmailOutputDTO> emailMap = _mapper.Map<List<EmailOutputDTO>>(emailDb);
            return emailMap;
        }

        public async Task<List<EmailOutputDTO>> GetAll()
        {
            List<EmailEntity> emailDb = await _repository.GetAll();
            List<EmailOutputDTO> emailMap = _mapper.Map<List<EmailOutputDTO>>(emailDb);
            return emailMap;
        }

        public async Task<EmailOutputDTO> Create(EmailInputDTO create)
        {
            EmailEntity emailCadastro = _mapper.Map<EmailEntity>(create);
            EmailEntity emailDb = await _repository.Create(emailCadastro);
            EmailOutputDTO emailMap = _mapper.Map<EmailOutputDTO>(emailDb);
            return emailMap;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<EmailOutputDTO> Update(int id, EmailInputDTO update)
        {
            EmailEntity buscarDb = await _repository.FindById(id);
            if (buscarDb == null)
            {
                throw new Exception("Médico não localizado");
            }
            EmailEntity emailUpdate = _mapper.Map<EmailEntity>(update);
            emailUpdate.Id = id;
            EmailEntity emailDb = await _repository.Update(emailUpdate);
            EmailOutputDTO emailMap = _mapper.Map<EmailOutputDTO>(emailDb);
            return emailMap;
        }
    }
}
