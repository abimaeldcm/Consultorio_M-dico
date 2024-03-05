using AutoMapper;
using Consultorio.Domain.Entity;
using Consultorio.Domain.Entity.InputDTOs;
using Consultorio.Domain.Entity.OutPutDTOs;

namespace Consultorio.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AtendimentoInputDTO, Atendimento>();
            CreateMap<Atendimento, AtendimentoOutputDTO>();

            CreateMap<EspecialidadeInputDTO, Especialidade>();
            CreateMap<Especialidade, EspecialidadeOutputDTO>();

            CreateMap<MedicoInputDTO, Medico>();
            CreateMap<Medico, MedicoOutputDTO>();

            CreateMap<PacienteInputDTO, Paciente>();
            CreateMap<Paciente, PacienteOutputDTO>();

            CreateMap<ServicoInputDTO, Servico>();
            CreateMap<Servico, ServicoOutputDTO>();
            
        }
    }
}
