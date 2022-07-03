using FluentValidation;
using HRManagement.Application.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.Employee.Command.CreateEmployee
{
	public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
	{
        private readonly IEmployeeRepository _employeeRepository;
        public CreateEmployeeCommandValidator(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

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

            RuleFor(e => e)
                .MustAsync(EmployeeNameAndDateOfBirthUnique)
                .WithMessage("An Employee with the same FirstName,LastName & date of birth already exists.");

        }

        private async Task<bool> EmployeeNameAndDateOfBirthUnique(CreateEmployeeCommand e, CancellationToken token)
        {
            return !(await _employeeRepository.IsEmployeeNameAndDateOfBirthUnique(e.FirstName,e.LastName, e.DateOfBirth));
        }
    }
}
