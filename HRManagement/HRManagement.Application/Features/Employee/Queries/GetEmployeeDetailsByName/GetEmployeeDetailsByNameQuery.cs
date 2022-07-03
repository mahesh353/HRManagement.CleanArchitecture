using HRManagement.Application.Features.Employee.Queries.GetEmployeeDetails;
using MediatR;
using System.Collections.Generic;

namespace HRManagement.Application.Features.Employee.Queries.GetEmployeeDetailsByName
{
	public class GetEmployeeDetailsByNameQuery : IRequest<List<EmployeeDetailsVM>>
	{
		public string Name { get; set; }
	}
}
