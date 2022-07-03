using System;
using System.ComponentModel.DataAnnotations;

namespace HRManagement.UI.ViewModels
{
	public class EditEmployeeViewModel
	{
		public int EmployeeId { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		public DateTime DateOfBirth { get; set; }

		[Required]
		public DateTime DateOfJoining { get; set; }

		[Required]
		public int DepartmentId { get; set; }
	}
}
