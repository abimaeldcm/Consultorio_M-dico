using AutoMapper;
using Consultorio.Application.Interface;
using Consultorio.Domain.Entity;
using Consultorio.Domain.Entity.InputDTOs;
using Consultorio.Domain.Entity.OutPutDTOs;
using Consultorio.Infra.Data.Interfaces;

namespace Consultorio.Application.Service
{
    public class ServiceService : ICRUDService<ServiceOutputDTO, ServiceInputDTO>
    {
        private readonly ICRUDRepository<ServiceEntity> _repository;
        private readonly IMapper _mapper;

        public ServiceService(ICRUDRepository<ServiceEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ServiceOutputDTO> FindById(int id)
        {
            ServiceEntity serviceDb = await _repository.FindById(id);
            ServiceOutputDTO serviceMap = _mapper.Map<ServiceOutputDTO>(serviceDb);
            return serviceMap;
        }

        public async Task<List<ServiceOutputDTO>> FindByText(string query)
        {
            List<ServiceEntity> serviceDb = await _repository.FindByText(query);
            List<ServiceOutputDTO> serviceMap = _mapper.Map<List<ServiceOutputDTO>>(serviceDb);
            return serviceMap;
        }

        public async Task<List<ServiceOutputDTO>> GetAll()
        {
            List<ServiceEntity> serviceDb = await _repository.GetAll();
            List<ServiceOutputDTO> serviceMap = _mapper.Map<List<ServiceOutputDTO>>(serviceDb);
            return serviceMap;
        }

        public async Task<ServiceOutputDTO> Create(ServiceInputDTO create)
        {
            ServiceEntity serviceCadastro = _mapper.Map<ServiceEntity>(create);
            ServiceEntity serviceDb = await _repository.Create(serviceCadastro);
            ServiceOutputDTO serviceMap = _mapper.Map<ServiceOutputDTO>(serviceDb);
            return serviceMap;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<ServiceOutputDTO> Update(int id, ServiceInputDTO update)
        {

            ServiceEntity buscarDb = await _repository.FindById(id);
            if (buscarDb == null)
            {
                throw new Exception("Serviço não localizado");
            }
            ServiceEntity serviceUpdate = _mapper.Map<ServiceEntity>(update);
            serviceUpdate.Id = id;
            ServiceEntity serviceDb = await _repository.Update(serviceUpdate);
            ServiceOutputDTO serviceMap = _mapper.Map<ServiceOutputDTO>(serviceDb);
            return serviceMap;
        }
    }
}
