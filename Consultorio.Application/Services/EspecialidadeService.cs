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
        private readonly ICRUDRepository<Specialty> _repository;
        private readonly IMapper _mapper;

        public SpecialityService(ICRUDRepository<Specialty> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SpecialityOutputDTO> FindById(int id)
        {
            Specialty specialityDb = await _repository.FindById(id);
            SpecialityOutputDTO specialityMap = _mapper.Map<SpecialityOutputDTO>(specialityDb);
            return specialityMap;
        }

        public async Task<List<SpecialityOutputDTO>> FindByText(string query)
        {
            List<Specialty> specialityDb = await _repository.FindByText(query);
            List<SpecialityOutputDTO> specialityMap = _mapper.Map<List<SpecialityOutputDTO>>(specialityDb);
            return specialityMap;
        }

        public async Task<List<SpecialityOutputDTO>> GetAll()
        {
            List<Specialty> specialityDb = await _repository.GetAll();
            List<SpecialityOutputDTO> specialityMap = _mapper.Map<List<SpecialityOutputDTO>>(specialityDb);
            return specialityMap;
        }

        public async Task<SpecialityOutputDTO> Create(SpecialityInputDTO create)
        {
            Specialty SpecialityCadastro = _mapper.Map<Specialty>(create);
            Specialty specialityDb = await _repository.Create(SpecialityCadastro);
            SpecialityOutputDTO specialityMap = _mapper.Map<SpecialityOutputDTO>(specialityDb);
            return specialityMap;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<SpecialityOutputDTO> Update(int id, SpecialityInputDTO update)
        {
            Specialty buscarDb = await _repository.FindById(id);
            if (buscarDb == null)
            {
                throw new Exception("Speciality não localizado");
            }
            Specialty SpecialityUpdate = _mapper.Map<Specialty>(update);
            SpecialityUpdate.Id = id;
            Specialty specialityDb = await _repository.Update(SpecialityUpdate);
            SpecialityOutputDTO specialityMap = _mapper.Map<SpecialityOutputDTO>(specialityDb);
            return specialityMap;
        }
    }
}
