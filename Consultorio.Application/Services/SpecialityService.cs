using AutoMapper;
using Consultorio.Application.Interface;
using Consultorio.Domain.Entity;
using Consultorio.Domain.Entity.InputDTOs;
using Consultorio.Domain.Entity.OutPutDTOs;
using Consultorio.Infra.Data.Interfaces;

namespace Consultorio.Application.Service
{
    public class SpecialityService : ICRUDService<SpecialityOutputDTO, SpecialityInputDTO>
    {
        private readonly ICRUDRepository<Speciality> _repository;
        private readonly IMapper _mapper;

        public SpecialityService(ICRUDRepository<Speciality> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SpecialityOutputDTO> FindById(int id)
        {
            Speciality specialityDb = await _repository.FindById(id);
            SpecialityOutputDTO specialityMap = _mapper.Map<SpecialityOutputDTO>(specialityDb);
            return specialityMap;
        }

        public async Task<List<SpecialityOutputDTO>> FindByText(string query)
        {
            List<Speciality> specialityDb = await _repository.FindByText(query);
            List<SpecialityOutputDTO> specialityMap = _mapper.Map<List<SpecialityOutputDTO>>(specialityDb);
            return specialityMap;
        }

        public async Task<List<SpecialityOutputDTO>> GetAll()
        {
            List<Speciality> specialityDb = await _repository.GetAll();
            List<SpecialityOutputDTO> specialityMap = _mapper.Map<List<SpecialityOutputDTO>>(specialityDb);
            return specialityMap;
        }

        public async Task<SpecialityOutputDTO> Create(SpecialityInputDTO create)
        {
            Speciality SpecialityCadastro = _mapper.Map<Speciality>(create);
            Speciality specialityDb = await _repository.Create(SpecialityCadastro);
            SpecialityOutputDTO specialityMap = _mapper.Map<SpecialityOutputDTO>(specialityDb);
            return specialityMap;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<SpecialityOutputDTO> Update(int id, SpecialityInputDTO update)
        {
            Speciality buscarDb = await _repository.FindById(id);
            if (buscarDb == null)
            {
                throw new Exception("Speciality não localizado");
            }
            Speciality SpecialityUpdate = _mapper.Map<Speciality>(update);
            SpecialityUpdate.Id = id;
            Speciality specialityDb = await _repository.Update(SpecialityUpdate);
            SpecialityOutputDTO specialityMap = _mapper.Map<SpecialityOutputDTO>(specialityDb);
            return specialityMap;
        }
    }
}
