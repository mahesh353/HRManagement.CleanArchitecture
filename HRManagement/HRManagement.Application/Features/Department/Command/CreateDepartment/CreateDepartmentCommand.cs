using MediatR;

namespace HRManagement.Application.Features.Department.Command.CreateDepartment
{
	public class CreateDepartmentCommand : IRequest<int>
    {        
        public string DepartmentName { get; set; }
    }
}
