using FluentValidation;
using HRManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.Department.Command.CreateDepartment
{
	public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
	{
        private readonly IDepartmentRepository _departmentRepository;
        public CreateDepartmentCommandValidator(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;

            RuleFor(p => p.DepartmentName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p)
              .MustAsync(IsDepartmentNameUnique)
              .WithMessage("Department with same name already exists.");

        }

        private async Task<bool> IsDepartmentNameUnique(CreateDepartmentCommand d, CancellationToken token)
        {
            return !(await _departmentRepository.IsDepartmentNameUnique(0,d.DepartmentName));
        }
    }
}
