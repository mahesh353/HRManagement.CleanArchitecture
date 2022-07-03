using MediatR;

namespace HRManagement.Application.Features.Department.Command.DeleteDepartment
{
	public class DeleteDepartmentCommand : IRequest
    {
        public int DepartmentId { get; set; }
    }
}
