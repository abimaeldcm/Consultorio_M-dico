using AutoMapper;
using Consultorio.Application.Interface;
using Consultorio.Domain.Entity;
using Consultorio.Domain.Entity.InputDTOs;
using Consultorio.Domain.Entity.OutPutDTOs;
using Consultorio.Infra.Data.Interfaces;

namespace Consultorio.Application.Service
{
    public class ServicoService : ICRUDService<ServiceOutputDTO, ServiceInputDTO>
    {
        private readonly ICRUDRepository<ServiceEntity> _repository;
        private readonly IMapper _mapper;

        public ServicoService(ICRUDRepository<ServiceEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ServiceOutputDTO> BuscarPorId(int id)
        {
            ServiceEntity servicoDb = await _repository.BuscarPorId(id);
            ServiceOutputDTO servicoMap = _mapper.Map<ServiceOutputDTO>(servicoDb);
            return servicoMap;
        }

        public async Task<List<ServiceOutputDTO>> BuscarPorTexto(string termoPesquisa)
        {
            List<ServiceEntity> servicoDb = await _repository.BuscarPorTexto(termoPesquisa);
            List<ServiceOutputDTO> servicoMap = _mapper.Map<List<ServiceOutputDTO>>(servicoDb);
            return servicoMap;
        }

        public async Task<List<ServiceOutputDTO>> BuscarTodos()
        {
            List<ServiceEntity> servicoDb = await _repository.BuscarTodos();
            List<ServiceOutputDTO> servicoMap = _mapper.Map<List<ServiceOutputDTO>>(servicoDb);
            return servicoMap;
        }

        public async Task<ServiceOutputDTO> Cadastrar(ServiceInputDTO cadastrar)
        {
            ServiceEntity servicoCadastro = _mapper.Map<ServiceEntity>(cadastrar);
            ServiceEntity servicoDb = await _repository.Cadastrar(servicoCadastro);
            ServiceOutputDTO servicoMap = _mapper.Map<ServiceOutputDTO>(servicoDb);
            return servicoMap;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<ServiceOutputDTO> Editar(int id, ServiceInputDTO editar)
        {

            ServiceEntity buscarDb = await _repository.BuscarPorId(id);
            if (buscarDb == null)
            {
                throw new Exception("Serviço não localizado");
            }
            ServiceEntity servicoEditar = _mapper.Map<ServiceEntity>(editar);
            servicoEditar.Id = id;
            ServiceEntity servicoDb = await _repository.Editar(servicoEditar);
            ServiceOutputDTO servicoMap = _mapper.Map<ServiceOutputDTO>(servicoDb);
            return servicoMap;
        }
    }
}
