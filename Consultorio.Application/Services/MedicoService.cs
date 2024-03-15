using AutoMapper;
using Consultorio.Application.Interface;
using Consultorio.Domain.Entity;
using Consultorio.Domain.Entity.InputDTOs;
using Consultorio.Domain.Entity.OutPutDTOs;
using Consultorio.Infra.Data.Interfaces;

namespace Consultorio.Application.Service
{
    public class MedicoService : ICRUDService<DoctorOutputDTO, DoctorInputDTO>
    {
        private readonly ICRUDRepository<Medico> _repository;
        private readonly IMapper _mapper;

        public MedicoService(ICRUDRepository<Medico> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DoctorOutputDTO> BuscarPorId(int id)
        {
            Medico medicoDb = await _repository.BuscarPorId(id);
            DoctorOutputDTO medicoMap = _mapper.Map<DoctorOutputDTO>(medicoDb);
            return medicoMap;
        }

        public async Task<List<DoctorOutputDTO>> BuscarPorTexto(string termoPesquisa)
        {
            List<Medico> medicoDb = await _repository.BuscarPorTexto(termoPesquisa);
            List<DoctorOutputDTO> medicoMap = _mapper.Map<List<DoctorOutputDTO>>(medicoDb);
            return medicoMap;
        }

        public async Task<List<DoctorOutputDTO>> BuscarTodos()
        {
            List<Medico> medicoDb = await _repository.BuscarTodos();
            List<DoctorOutputDTO> medicoMap = _mapper.Map<List<DoctorOutputDTO>>(medicoDb);
            return medicoMap;
        }

        public async Task<DoctorOutputDTO> Cadastrar(DoctorInputDTO cadastrar)
        {
            Medico MedicoCadastro = _mapper.Map<Medico>(cadastrar);
            Medico medicoDb = await _repository.Cadastrar(MedicoCadastro);
            DoctorOutputDTO medicoMap = _mapper.Map<DoctorOutputDTO>(medicoDb);
            return medicoMap;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<DoctorOutputDTO> Editar(int id, DoctorInputDTO editar)
        {
            Medico buscarDb = await _repository.BuscarPorId(id);
            if (buscarDb == null)
            {
                throw new Exception("Médico não localizado");
            }
            Medico medicoEditar = _mapper.Map<Medico>(editar);
            medicoEditar.Id = id;
            Medico medicoDb = await _repository.Editar(medicoEditar);
            DoctorOutputDTO medicoMap = _mapper.Map<DoctorOutputDTO>(medicoDb);
            return medicoMap;
        }
    }
}
