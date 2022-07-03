using System.ComponentModel;

namespace HRManagement.Application.Features.Employee.Queries.GetEmployeeDetails
{
	public class DepartmentVM
	{
		public int DepartmentId { get; set; }

		[DisplayName("Department Name")]
		public string DepartmentName { get; set; }
	}
}
