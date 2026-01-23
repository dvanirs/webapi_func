using FluentValidation;
using System;

namespace WebApi_Func.Application.Commands.UpdateUser
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Nome).NotEmpty().MaximumLength(150);
            RuleFor(x => x.Matricula).NotEmpty().MaximumLength(50);
            RuleFor(x => x.DataNascimento).LessThan(DateTime.Now);
        }
    }
}
