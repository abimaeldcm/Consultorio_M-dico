using AutoMapper;
using Consultorio.Application.Interface;
using Consultorio.Domain.Entity;
using Consultorio.Domain.Entity.InputDTOs;
using Consultorio.Domain.Entity.OutPutDTOs;
using Consultorio.Infra.Data.Interfaces;

namespace Consultorio.Application.Service
{
    public class PacienteService : ICRUDService<PacienteOutputDTO, PacienteInputDTO>
    {
        private readonly ICRUDRepository<Paciente> _repository;
        private readonly IMapper _mapper;

        public PacienteService(ICRUDRepository<Paciente> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PacienteOutputDTO> BuscarPorId(int id)
        {
            Paciente pacienteDb = await _repository.BuscarPorId(id);
            PacienteOutputDTO pacienteMap = _mapper.Map<PacienteOutputDTO>(pacienteDb);
            return pacienteMap;
        }

        public async Task<List<PacienteOutputDTO>> BuscarPorTexto(string termoPesquisa)
        {
            List<Paciente> pacienteDb = await _repository.BuscarPorTexto(termoPesquisa);
            List<PacienteOutputDTO> pacienteMap = _mapper.Map<List<PacienteOutputDTO>>(pacienteDb);
            return pacienteMap;
        }

        public async Task<List<PacienteOutputDTO>> BuscarTodos()
        {
            List<Paciente> pacienteDb = await _repository.BuscarTodos();
            List<PacienteOutputDTO> pacienteMap = _mapper.Map<List<PacienteOutputDTO>>(pacienteDb);
            return pacienteMap;
        }

        public async Task<PacienteOutputDTO> Cadastrar(PacienteInputDTO cadastrar)
        {
            Paciente pacienteCadastro = _mapper.Map<Paciente>(cadastrar);
            Paciente pacienteDb = await _repository.Cadastrar(pacienteCadastro);
            PacienteOutputDTO pacienteMap = _mapper.Map<PacienteOutputDTO>(pacienteDb);
            return pacienteMap;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<PacienteOutputDTO> Editar(int id, PacienteInputDTO editar)
        {
            Paciente buscarDb = await _repository.BuscarPorId(id);
            if (buscarDb == null)
            {
                throw new Exception("Paciente não localizado");
            }
            Paciente pacienteEditar = _mapper.Map<Paciente>(buscarDb);
            Paciente pacienteDb = await _repository.Editar(pacienteEditar);
            PacienteOutputDTO pacienteMap = _mapper.Map<PacienteOutputDTO>(pacienteDb);
            return pacienteMap;
        }

    }
}
