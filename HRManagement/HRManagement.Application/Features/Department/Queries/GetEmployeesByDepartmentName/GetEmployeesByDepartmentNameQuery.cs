using HRManagement.Application.Features.Employee.Queries.GetEmployeeListByDepartment;
using MediatR;
using System.Collections.Generic;

namespace HRManagement.Application.Features.Department.Queries.GetEmployeesByDepartmentName
{
	public class GetEmployeesByDepartmentNameQuery : IRequest<List<DepartmentEmployeeListVM>>
	{
		public string DepartmentName { get; set; }

	}
}
