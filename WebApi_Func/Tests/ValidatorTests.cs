using Xunit;
using FluentValidation.TestHelper;
using WebApi_Func.Application.Commands.CreateUser;
using WebApi_Func.Application.Commands.UpdateUser;
using System;

namespace WebApi_Func.Tests
{
    public class ValidatorTests
    {
        private readonly CreateUserValidator _createValidator;
        private readonly UpdateUserValidator _updateValidator;

        public ValidatorTests()
        {
            _createValidator = new CreateUserValidator();
            _updateValidator = new UpdateUserValidator();
        }

        [Fact]
        public void CreateUser_Should_Have_Error_When_Nome_Is_Empty()
        {
            var command = new CreateUserCommand { Nome = "" };
            var result = _createValidator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [Fact]
        public void CreateUser_Should_Have_Error_When_DataNascimento_Is_Future()
        {
            var command = new CreateUserCommand { DataNascimento = DateTime.Now.AddDays(1) };
            var result = _createValidator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.DataNascimento);
        }

        [Fact]
        public void UpdateUser_Should_Have_Error_When_Id_Is_Zero()
        {
            var command = new UpdateUserCommand { Id = 0 };
            var result = _updateValidator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }
    }
}
