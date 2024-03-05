using AutoMapper;
using Consultorio.Application.Interface;
using Consultorio.Domain.Entity;
using Consultorio.Domain.Entity.InputDTOs;
using Consultorio.Domain.Entity.OutPutDTOs;
using Consultorio.Infra.Data.Interfaces;

namespace Consultorio.Application.Service
{
    public class EspecialidadeService : ICRUDService<EspecialidadeOutputDTO, EspecialidadeInputDTO>
    {
        private readonly ICRUDRepository<Especialidade> _repository;
        private readonly IMapper _mapper;

        public EspecialidadeService(ICRUDRepository<Especialidade> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EspecialidadeOutputDTO> BuscarPorId(int id)
        {
            Especialidade EspecialidadeDb = await _repository.BuscarPorId(id);
            EspecialidadeOutputDTO EspecialidadeMap = _mapper.Map<EspecialidadeOutputDTO>(EspecialidadeDb);
            return EspecialidadeMap;
        }

        public async Task<List<EspecialidadeOutputDTO>> BuscarPorTexto(string termoPesquisa)
        {
            List<Especialidade> EspecialidadeDb = await _repository.BuscarPorTexto(termoPesquisa);
            List<EspecialidadeOutputDTO> EspecialidadeMap = _mapper.Map<List<EspecialidadeOutputDTO>>(EspecialidadeDb);
            return EspecialidadeMap;
        }

        public async Task<List<EspecialidadeOutputDTO>> BuscarTodos()
        {
            List<Especialidade> EspecialidadeDb = await _repository.BuscarTodos();
            List<EspecialidadeOutputDTO> EspecialidadeMap = _mapper.Map<List<EspecialidadeOutputDTO>>(EspecialidadeDb);
            return EspecialidadeMap;
        }

        public async Task<EspecialidadeOutputDTO> Cadastrar(EspecialidadeInputDTO cadastrar)
        {
            Especialidade EspecialidadeCadastro = _mapper.Map<Especialidade>(cadastrar);
            Especialidade EspecialidadeDb = await _repository.Cadastrar(EspecialidadeCadastro);
            EspecialidadeOutputDTO EspecialidadeMap = _mapper.Map<EspecialidadeOutputDTO>(EspecialidadeDb);
            return EspecialidadeMap;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<EspecialidadeOutputDTO> Editar(int id, EspecialidadeInputDTO editar)
        {
            Especialidade buscarDb = await _repository.BuscarPorId(id);
            if (buscarDb == null)
            {
                throw new Exception("Especialidade não localizado");
            }
            Especialidade especialidadeEditar = _mapper.Map<Especialidade>(buscarDb);
            Especialidade especialidadeDb = await _repository.Editar(especialidadeEditar);
            EspecialidadeOutputDTO especialidadeMap = _mapper.Map<EspecialidadeOutputDTO>(especialidadeDb);
            return especialidadeMap;
        }
    }
}
