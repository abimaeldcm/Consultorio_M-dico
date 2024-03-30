using Consultorio.Domain.Entity.InputDTOs;
using FluentValidation;

namespace Consultorio.Application.Validations
{
    public class UserValidation : AbstractValidator<UserInputDTO>
    {
        public UserValidation()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("IdPaciente não pode ser vazio")
                .MaximumLength(30).WithMessage("Nome muito longo");

            RuleFor(e => e.Password)
                .NotEmpty().WithMessage("IdServico não pode ser vazio")
                .MaximumLength(200).WithMessage("Senhia muito longo");
            ;
        }
    }
}
