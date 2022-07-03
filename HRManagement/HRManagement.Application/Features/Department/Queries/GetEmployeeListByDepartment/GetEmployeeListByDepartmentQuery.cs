using MediatR;
using System.Collections.Generic;

namespace HRManagement.Application.Features.Employee.Queries.GetEmployeeListByDepartment
{
	public class GetEmployeeListByDepartmentQuery : IRequest<List<DepartmentEmployeeListVM>>
    {
        public int DepartmentID { get; set; }
    }
}
