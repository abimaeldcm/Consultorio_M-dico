using AutoMapper;
using Consultorio.Application.Interface;
using Consultorio.Domain.Entity;
using Consultorio.Domain.Entity.InputDTOs;
using Consultorio.Domain.Entity.OutPutDTOs;
using Consultorio.Infra.Data.Interfaces;

namespace Consultorio.Application.Service
{
    public class ServicoService : ICRUDService<ServicoOutputDTO, ServicoInputDTO>
    {
        private readonly ICRUDRepository<Servico> _repository;
        private readonly IMapper _mapper;

        public ServicoService(ICRUDRepository<Servico> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ServicoOutputDTO> BuscarPorId(int id)
        {
            Servico servicoDb = await _repository.BuscarPorId(id);
            ServicoOutputDTO servicoMap = _mapper.Map<ServicoOutputDTO>(servicoDb);
            return servicoMap;
        }

        public async Task<List<ServicoOutputDTO>> BuscarPorTexto(string termoPesquisa)
        {
            List<Servico> servicoDb = await _repository.BuscarPorTexto(termoPesquisa);
            List<ServicoOutputDTO> servicoMap = _mapper.Map<List<ServicoOutputDTO>>(servicoDb);
            return servicoMap;
        }

        public async Task<List<ServicoOutputDTO>> BuscarTodos()
        {
            List<Servico> servicoDb = await _repository.BuscarTodos();
            List<ServicoOutputDTO> servicoMap = _mapper.Map<List<ServicoOutputDTO>>(servicoDb);
            return servicoMap;
        }

        public async Task<ServicoOutputDTO> Cadastrar(ServicoInputDTO cadastrar)
        {
            Servico servicoCadastro = _mapper.Map<Servico>(cadastrar);
            Servico servicoDb = await _repository.Cadastrar(servicoCadastro);
            ServicoOutputDTO servicoMap = _mapper.Map<ServicoOutputDTO>(servicoDb);
            return servicoMap;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<ServicoOutputDTO> Editar(int id, ServicoInputDTO editar)
        {

            Servico buscarDb = await _repository.BuscarPorId(id);
            if (buscarDb == null)
            {
                throw new Exception("Serviço não localizado");
            }
            Servico servicoEditar = _mapper.Map<Servico>(buscarDb);
            Servico servicoDb = await _repository.Editar(servicoEditar);
            ServicoOutputDTO servicoMap = _mapper.Map<ServicoOutputDTO>(servicoDb);
            return servicoMap;
        }
    }
}
