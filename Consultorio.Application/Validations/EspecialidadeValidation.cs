using Consultorio.Domain.Entity;
using Consultorio.Domain.Entity.InputDTOs;
using FluentValidation;

namespace Consultorio.Application.Validations
{
    public class EspecialidadeValidation : AbstractValidator<SpecialityInputDTO>
    {
        public EspecialidadeValidation()
        {
            RuleFor(e => e.EspecialidadeMedica)
                .MaximumLength(100)
                .WithMessage("Especialidade com o nome muito grande");
        }
    }
}
