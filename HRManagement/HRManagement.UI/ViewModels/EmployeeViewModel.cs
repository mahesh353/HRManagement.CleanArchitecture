using HRManagement.Application.Features.Department.Queries.GetDepartmentDetails;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRManagement.UI.ViewModels
{
	public class EmployeeViewModel
	{
		[Required]
		public string FirstName { get; set; }
		
		[Required]
		public string LastName { get; set; }

		[Required]
		public DateTime? DateOfBirth { get; set; }

		[Required]
		public DateTime? DateOfJoining { get; set; }

		[Required]
		public int DepartmentId { get; set; }

		public List<DepartmentDetailVM> Departments { get; set; }
	}
}
