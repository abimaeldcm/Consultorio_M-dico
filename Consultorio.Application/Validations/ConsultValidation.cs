using Consultorio.Domain.Entity.InputDTOs;
using FluentValidation;

namespace Consultorio.Application.Validations
{
    public class ConsultValidation : AbstractValidator<ConsultInputDTO>
    {
        public ConsultValidation()
        {
            RuleFor(e => e.IdDoctor)
                .NotEmpty().WithMessage("IdMedico não pode ser vazio")
                .NotEqual(0).WithMessage("IdMedico não pode ser igual a 0");

            RuleFor(e => e.IdPatient)
                .NotEmpty().WithMessage("IdPaciente não pode ser vazio")
                .NotEqual(0).WithMessage("IdPaciente não pode ser igual a 0");

            RuleFor(e => e.IdService)
                .NotEmpty().WithMessage("IdServico não pode ser vazio")
                .NotEqual(0).WithMessage("IdServico não pode ser igual a 0");

            RuleFor(e => (int)e.Convenio)
                .InclusiveBetween(0,1)
                .WithMessage("Convênio deve ser 0 (não) ou 1 (sim)");

            RuleFor(e => e.Start).GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("A data de início não pode ser menor que a data atual");

            RuleFor(e => e.End).GreaterThan(ini => ini.Start)
                .WithMessage("A data/hora de fim não pode ser menor que a data/hora de início"); 
        }
    }
}
