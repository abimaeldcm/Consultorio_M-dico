using Consultorio.Domain.Entity;
using Consultorio.Domain.Entity.InputDTOs;
using FluentValidation;

namespace Consultorio.Application.Validations
{
    public class SpecialityValidation : AbstractValidator<SpecialityInputDTO>
    {
        public SpecialityValidation()
        {
            RuleFor(e => e.MedicalSpecialty)
                .MaximumLength(100)
                .WithMessage("Especialidade com o nome muito grande");
        }
    }
}
