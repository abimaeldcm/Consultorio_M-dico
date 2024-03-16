using AutoMapper;
using Consultorio.Application.Interface;
using Consultorio.Domain.Entity;
using Consultorio.Domain.Entity.InputDTOs;
using Consultorio.Domain.Entity.OutPutDTOs;
using Consultorio.Infra.Data.Interfaces;

namespace Consultorio.Application.Service
{
    public class DoctorService : ICRUDService<DoctorOutputDTO, DoctorInputDTO>
    {
        private readonly ICRUDRepository<Doctor> _repository;
        private readonly IMapper _mapper;

        public DoctorService(ICRUDRepository<Doctor> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DoctorOutputDTO> FindById(int id)
        {
            Doctor doctorDb = await _repository.FindById(id);
            DoctorOutputDTO doctorMap = _mapper.Map<DoctorOutputDTO>(doctorDb);
            return doctorMap;
        }

        public async Task<List<DoctorOutputDTO>> FindByText(string query)
        {
            List<Doctor> doctorDb = await _repository.FindByText(query);
            List<DoctorOutputDTO> doctorMap = _mapper.Map<List<DoctorOutputDTO>>(doctorDb);
            return doctorMap;
        }

        public async Task<List<DoctorOutputDTO>> GetAll()
        {
            List<Doctor> doctorDb = await _repository.GetAll();
            List<DoctorOutputDTO> doctorMap = _mapper.Map<List<DoctorOutputDTO>>(doctorDb);
            return doctorMap;
        }

        public async Task<DoctorOutputDTO> Create(DoctorInputDTO create)
        {
            Doctor doctorCadastro = _mapper.Map<Doctor>(create);
            Doctor doctorDb = await _repository.Create(doctorCadastro);
            DoctorOutputDTO doctorMap = _mapper.Map<DoctorOutputDTO>(doctorDb);
            return doctorMap;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<DoctorOutputDTO> Update(int id, DoctorInputDTO update)
        {
            Doctor buscarDb = await _repository.FindById(id);
            if (buscarDb == null)
            {
                throw new Exception("Médico não localizado");
            }
            Doctor doctorUpdate = _mapper.Map<Doctor>(update);
            doctorUpdate.Id = id;
            Doctor doctorDb = await _repository.Update(doctorUpdate);
            DoctorOutputDTO doctorMap = _mapper.Map<DoctorOutputDTO>(doctorDb);
            return doctorMap;
        }
    }
}
