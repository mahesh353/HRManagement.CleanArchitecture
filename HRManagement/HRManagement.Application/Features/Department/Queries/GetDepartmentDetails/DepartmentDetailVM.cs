using System.ComponentModel;

namespace HRManagement.Application.Features.Department.Queries.GetDepartmentDetails
{
	public class DepartmentDetailVM
    {
        [DisplayName("Department Id")]
        public int DepartmentId { get; set; }

        [DisplayName("Department Name")]
        public string DepartmentName { get; set; }
    }
}
