using AutoMapper;
using Consultorio.Application.Interface;
using Consultorio.Domain.Entity;
using Consultorio.Domain.Entity.InputDTOs;
using Consultorio.Domain.Entity.OutPutDTOs;
using Consultorio.Infra.Data.Interfaces;

namespace Consultorio.Application.Service
{
    public class PatientService : ICRUDService<PatientOutputDTO, PatientInputDTO>
    {
        private readonly ICRUDRepository<Patient> _repository;
        private readonly IMapper _mapper;

        public PatientService(ICRUDRepository<Patient> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PatientOutputDTO> FindById(int id)
        {
            Patient patientDb = await _repository.FindById(id);
            PatientOutputDTO patientMap = _mapper.Map<PatientOutputDTO>(patientDb);
            return patientMap;
        }

        public async Task<List<PatientOutputDTO>> FindByText(string query)
        {
            List<Patient> patientDb = await _repository.FindByText(query);
            List<PatientOutputDTO> patientMap = _mapper.Map<List<PatientOutputDTO>>(patientDb);
            return patientMap;
        }

        public async Task<List<PatientOutputDTO>> GetAll()
        {
            List<Patient> patientDb = await _repository.GetAll();
            List<PatientOutputDTO> patientMap = _mapper.Map<List<PatientOutputDTO>>(patientDb);
            return patientMap;
        }

        public async Task<PatientOutputDTO> Create(PatientInputDTO create)
        {
            Patient patientCadastro = _mapper.Map<Patient>(create);
            Patient patientDb = await _repository.Create(patientCadastro);
            PatientOutputDTO patientMap = _mapper.Map<PatientOutputDTO>(patientDb);
            return patientMap;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<PatientOutputDTO> Update(int id, PatientInputDTO update)
        {
            Patient buscarDb = await _repository.FindById(id);
            if (buscarDb == null)
            {
                throw new Exception("patient não localizado");
            }
            Patient patientUpdate = _mapper.Map<Patient>(update);
            patientUpdate.Id = id;
            Patient patientDb = await _repository.Update(patientUpdate);
            PatientOutputDTO patientMap = _mapper.Map<PatientOutputDTO>(patientDb);
            return patientMap;
        }

    }
}
