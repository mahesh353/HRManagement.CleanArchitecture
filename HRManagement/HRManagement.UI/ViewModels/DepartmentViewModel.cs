using System.ComponentModel.DataAnnotations;

namespace HRManagement.UI.ViewModels
{
	public class DepartmentViewModel
	{
		[Required]
		public string DepartmentName { get; set; }
	}
}
