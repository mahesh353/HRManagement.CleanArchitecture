using MediatR;

namespace HRManagement.Application.Features.Employee.Queries.GetEmployeeDetails
{
	public class GetEmployeeDetailsQuery : IRequest<EmployeeDetailsVM>
	{
		public int EmployeeId { get; set; }
	}
}
