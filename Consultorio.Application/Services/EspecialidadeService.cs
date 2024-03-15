using AutoMapper;
using Consultorio.Application.Interface;
using Consultorio.Domain.Entity;
using Consultorio.Domain.Entity.InputDTOs;
using Consultorio.Domain.Entity.OutPutDTOs;
using Consultorio.Infra.Data.Interfaces;

namespace Consultorio.Application.Service
{
    public class EspecialidadeService : ICRUDService<SpecialityOutputDTO, SpecialityInputDTO>
    {
        private readonly ICRUDRepository<Specialty> _repository;
        private readonly IMapper _mapper;

        public EspecialidadeService(ICRUDRepository<Specialty> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SpecialityOutputDTO> BuscarPorId(int id)
        {
            Specialty EspecialidadeDb = await _repository.BuscarPorId(id);
            SpecialityOutputDTO EspecialidadeMap = _mapper.Map<SpecialityOutputDTO>(EspecialidadeDb);
            return EspecialidadeMap;
        }

        public async Task<List<SpecialityOutputDTO>> BuscarPorTexto(string termoPesquisa)
        {
            List<Specialty> EspecialidadeDb = await _repository.BuscarPorTexto(termoPesquisa);
            List<SpecialityOutputDTO> EspecialidadeMap = _mapper.Map<List<SpecialityOutputDTO>>(EspecialidadeDb);
            return EspecialidadeMap;
        }

        public async Task<List<SpecialityOutputDTO>> BuscarTodos()
        {
            List<Specialty> EspecialidadeDb = await _repository.BuscarTodos();
            List<SpecialityOutputDTO> EspecialidadeMap = _mapper.Map<List<SpecialityOutputDTO>>(EspecialidadeDb);
            return EspecialidadeMap;
        }

        public async Task<SpecialityOutputDTO> Cadastrar(SpecialityInputDTO cadastrar)
        {
            Specialty EspecialidadeCadastro = _mapper.Map<Specialty>(cadastrar);
            Specialty EspecialidadeDb = await _repository.Cadastrar(EspecialidadeCadastro);
            SpecialityOutputDTO EspecialidadeMap = _mapper.Map<SpecialityOutputDTO>(EspecialidadeDb);
            return EspecialidadeMap;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<SpecialityOutputDTO> Editar(int id, SpecialityInputDTO editar)
        {
            Specialty buscarDb = await _repository.BuscarPorId(id);
            if (buscarDb == null)
            {
                throw new Exception("Especialidade não localizado");
            }
            Specialty especialidadeEditar = _mapper.Map<Specialty>(editar);
            especialidadeEditar.Id = id;
            Specialty especialidadeDb = await _repository.Editar(especialidadeEditar);
            SpecialityOutputDTO especialidadeMap = _mapper.Map<SpecialityOutputDTO>(especialidadeDb);
            return especialidadeMap;
        }
    }
}
