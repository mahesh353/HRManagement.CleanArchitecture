using FluentValidation;
using HRManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.Department.Command.UpdateDepartment
{
	public class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
	{
        private readonly IDepartmentRepository _departmentRepository;
        public UpdateDepartmentCommandValidator(IDepartmentRepository departmentRepository)
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

        private async Task<bool> IsDepartmentNameUnique(UpdateDepartmentCommand d, CancellationToken token)
        {
            return !(await _departmentRepository.IsDepartmentNameUnique(d.DepartmentId,d.DepartmentName));
        }
    }
}
