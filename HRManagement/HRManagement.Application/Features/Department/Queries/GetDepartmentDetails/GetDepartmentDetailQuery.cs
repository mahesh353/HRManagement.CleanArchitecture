using MediatR;

namespace HRManagement.Application.Features.Department.Queries.GetDepartmentDetails
{
	public class GetDepartmentDetailQuery : IRequest<DepartmentDetailVM>
    {
        public int DepartmentId { get; set; }
    }
}
