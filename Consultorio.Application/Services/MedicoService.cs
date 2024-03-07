using AutoMapper;
using Consultorio.Application.Interface;
using Consultorio.Domain.Entity;
using Consultorio.Domain.Entity.InputDTOs;
using Consultorio.Domain.Entity.OutPutDTOs;
using Consultorio.Infra.Data.Interfaces;

namespace Consultorio.Application.Service
{
    public class MedicoService : ICRUDService<MedicoOutputDTO, MedicoInputDTO>
    {
        private readonly ICRUDRepository<Medico> _repository;
        private readonly IMapper _mapper;

        public MedicoService(ICRUDRepository<Medico> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MedicoOutputDTO> BuscarPorId(int id)
        {
            Medico medicoDb = await _repository.BuscarPorId(id);
            MedicoOutputDTO medicoMap = _mapper.Map<MedicoOutputDTO>(medicoDb);
            return medicoMap;
        }

        public async Task<List<MedicoOutputDTO>> BuscarPorTexto(string termoPesquisa)
        {
            List<Medico> medicoDb = await _repository.BuscarPorTexto(termoPesquisa);
            List<MedicoOutputDTO> medicoMap = _mapper.Map<List<MedicoOutputDTO>>(medicoDb);
            return medicoMap;
        }

        public async Task<List<MedicoOutputDTO>> BuscarTodos()
        {
            List<Medico> medicoDb = await _repository.BuscarTodos();
            List<MedicoOutputDTO> medicoMap = _mapper.Map<List<MedicoOutputDTO>>(medicoDb);
            return medicoMap;
        }

        public async Task<MedicoOutputDTO> Cadastrar(MedicoInputDTO cadastrar)
        {
            Medico MedicoCadastro = _mapper.Map<Medico>(cadastrar);
            Medico medicoDb = await _repository.Cadastrar(MedicoCadastro);
            MedicoOutputDTO medicoMap = _mapper.Map<MedicoOutputDTO>(medicoDb);
            return medicoMap;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<MedicoOutputDTO> Editar(int id, MedicoInputDTO editar)
        {
            Medico buscarDb = await _repository.BuscarPorId(id);
            if (buscarDb == null)
            {
                throw new Exception("Médico não localizado");
            }
            Medico medicoEditar = _mapper.Map<Medico>(editar);
            medicoEditar.Id = id;
            Medico medicoDb = await _repository.Editar(medicoEditar);
            MedicoOutputDTO medicoMap = _mapper.Map<MedicoOutputDTO>(medicoDb);
            return medicoMap;
        }
    }
}
