using AutoMapper;
using Consultorio.Application.Interface;
using Consultorio.Domain.Entity;
using Consultorio.Domain.Entity.InputDTOs;
using Consultorio.Domain.Entity.OutPutDTOs;
using Consultorio.Infra.Data.Interfaces;

namespace Consultorio.Application.Service
{
    public class PacienteService : ICRUDService<PatientOutputDTO, PatientInputDTO>
    {
        private readonly ICRUDRepository<Paciente> _repository;
        private readonly IMapper _mapper;

        public PacienteService(ICRUDRepository<Paciente> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PatientOutputDTO> BuscarPorId(int id)
        {
            Paciente pacienteDb = await _repository.BuscarPorId(id);
            PatientOutputDTO pacienteMap = _mapper.Map<PatientOutputDTO>(pacienteDb);
            return pacienteMap;
        }

        public async Task<List<PatientOutputDTO>> BuscarPorTexto(string termoPesquisa)
        {
            List<Paciente> pacienteDb = await _repository.BuscarPorTexto(termoPesquisa);
            List<PatientOutputDTO> pacienteMap = _mapper.Map<List<PatientOutputDTO>>(pacienteDb);
            return pacienteMap;
        }

        public async Task<List<PatientOutputDTO>> BuscarTodos()
        {
            List<Paciente> pacienteDb = await _repository.BuscarTodos();
            List<PatientOutputDTO> pacienteMap = _mapper.Map<List<PatientOutputDTO>>(pacienteDb);
            return pacienteMap;
        }

        public async Task<PatientOutputDTO> Cadastrar(PatientInputDTO cadastrar)
        {
            Paciente pacienteCadastro = _mapper.Map<Paciente>(cadastrar);
            Paciente pacienteDb = await _repository.Cadastrar(pacienteCadastro);
            PatientOutputDTO pacienteMap = _mapper.Map<PatientOutputDTO>(pacienteDb);
            return pacienteMap;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<PatientOutputDTO> Editar(int id, PatientInputDTO editar)
        {
            Paciente buscarDb = await _repository.BuscarPorId(id);
            if (buscarDb == null)
            {
                throw new Exception("Paciente não localizado");
            }
            Paciente pacienteEditar = _mapper.Map<Paciente>(editar);
            pacienteEditar.Id = id;
            Paciente pacienteDb = await _repository.Editar(pacienteEditar);
            PatientOutputDTO pacienteMap = _mapper.Map<PatientOutputDTO>(pacienteDb);
            return pacienteMap;
        }

    }
}
