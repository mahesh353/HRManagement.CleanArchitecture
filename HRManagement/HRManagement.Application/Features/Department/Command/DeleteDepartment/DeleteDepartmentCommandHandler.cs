using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.Department.Command.DeleteDepartment
{
	public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DeleteDepartmentCommandHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<Unit> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var departmentToDelete = await _departmentRepository.GetByIdAsync(request.DepartmentId);
            
            if (departmentToDelete == null)
            {
                throw new NotFoundException(nameof(Employee), request.DepartmentId);
            }

            await _departmentRepository.DeleteAsync(departmentToDelete);

            return Unit.Value;
        }
    }
}
