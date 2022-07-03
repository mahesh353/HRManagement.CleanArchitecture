using FluentValidation;
using HRManagement.Application.Contracts;
using System;

namespace HRManagement.Application.Features.Employee.Command.UpdateEmployee
{
	public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
	{
        public UpdateEmployeeCommandValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.DateOfBirth)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .LessThan(DateTime.Now);

            RuleFor(p => p.DateOfJoining)
             .NotEmpty().WithMessage("{PropertyName} is required.")
             .NotNull();

            RuleFor(p => p.DepartmentId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);

        }
	
    }
}
