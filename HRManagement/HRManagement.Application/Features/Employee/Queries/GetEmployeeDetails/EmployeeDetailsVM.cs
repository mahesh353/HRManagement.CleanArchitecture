using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HRManagement.Application.Features.Employee.Queries.GetEmployeeDetails
{
	public class EmployeeDetailsVM
	{
		public int EmployeeId { get; set; }

		[DisplayName("First Name")]
		public string FirstName { get; set; }

		[DisplayName("Last Name")]
		public string LastName { get; set; }

		[DisplayName("Date Of Birth")]
		[DisplayFormat(DataFormatString = "{0:d}")]
		public DateTime DateOfBirth { get; set; }

		[DisplayName("Date Of Joining")]
		[DisplayFormat(DataFormatString = "{0:d}")]
		public DateTime DateOfJoining { get; set; }

		public DepartmentVM Department { get; set; }
	}
}
