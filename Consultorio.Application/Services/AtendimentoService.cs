using AutoMapper;
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
        private readonly IMapper _mapper;

        public AtendimentoService(ICRUDRepository<Atendimento> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
            List <AtendimentoOutputDTO> atendimentoMap = _mapper.Map<List<AtendimentoOutputDTO>>(atendimentoDb);
            return atendimentoMap;
        }

        public async Task<AtendimentoOutputDTO> Cadastrar(AtendimentoInputDTO cadastrar)
        {
            Atendimento atendimentoCadastro = _mapper.Map<Atendimento>(cadastrar);
            Atendimento atendimentoDb = await _repository.Cadastrar(atendimentoCadastro);
            AtendimentoOutputDTO atendimentoMap = _mapper.Map<AtendimentoOutputDTO>(atendimentoDb);
            return atendimentoMap;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
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
