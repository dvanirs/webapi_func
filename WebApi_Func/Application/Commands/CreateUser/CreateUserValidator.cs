using FluentValidation;

namespace WebApi_Func.Application.Commands.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().MaximumLength(150);
            RuleFor(x => x.Matricula).NotEmpty().MaximumLength(50);
            RuleFor(x => x.DataNascimento).LessThan(DateTime.Now).WithMessage("Data de nascimento deve ser no passado.");
        }
    }
}
