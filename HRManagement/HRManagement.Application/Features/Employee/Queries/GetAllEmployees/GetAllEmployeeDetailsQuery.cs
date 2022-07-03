using HRManagement.Application.Features.Employee.Queries.GetEmployeeDetails;
using MediatR;
using System.Collections.Generic;

namespace HRManagement.Application.Features.Employee.Queries.GetAllEmployees
{
	public class GetAllEmployeeDetailsQuery : IRequest<List<EmployeeDetailsVM>>
	{
	}
}
