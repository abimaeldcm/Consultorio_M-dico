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
            CreateMap<ConsultInputDTO, Consult>();
            CreateMap<Consult, ConsultOutputDTO>();

            CreateMap<SpecialityInputDTO, Specialty>();
            CreateMap<Specialty, SpecialityOutputDTO>();

            CreateMap<DoctorInputDTO, Medico>();
            CreateMap<Medico, DoctorOutputDTO>();

            CreateMap<PatientInputDTO, Paciente>();
            CreateMap<Paciente, PatientOutputDTO>();

            CreateMap<ServiceInputDTO, ServiceEntity>();
            CreateMap<ServiceEntity, ServiceOutputDTO>();
            
        }
    }
}
