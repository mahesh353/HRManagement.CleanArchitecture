using MediatR;

namespace HRManagement.Application.Features.Employee.Command.DeleteEmployee
{
	public class DeleteEmployeeCommand : IRequest
    {
        public int EmployeeId { get; set; }
    }
}
