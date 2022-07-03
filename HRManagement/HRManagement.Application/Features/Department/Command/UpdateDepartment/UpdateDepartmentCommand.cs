using MediatR;

namespace HRManagement.Application.Features.Department.Command.UpdateDepartment
{
	public class UpdateDepartmentCommand : IRequest
    {
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }
    }
}
