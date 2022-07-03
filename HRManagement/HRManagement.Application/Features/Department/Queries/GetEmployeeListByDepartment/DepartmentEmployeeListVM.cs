using System.Collections.Generic;

namespace HRManagement.Application.Features.Employee.Queries.GetEmployeeListByDepartment
{
	public class DepartmentEmployeeListVM
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<DepartmentEmployeeDto> Employees { get; set; }
    }
}
