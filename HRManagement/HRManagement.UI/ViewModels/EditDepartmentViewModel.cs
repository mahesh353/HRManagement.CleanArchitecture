using System.ComponentModel.DataAnnotations;

namespace HRManagement.UI.ViewModels
{
	public class EditDepartmentViewModel
	{
		public int DepartmentId { get; set; }

		[Required]
		public string DepartmentName { get; set; }
	}
}
