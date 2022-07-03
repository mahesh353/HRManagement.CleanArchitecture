using HRManagement.Application.Features.Department.Queries.GetDepartmentDetails;
using MediatR;
using System.Collections.Generic;

namespace HRManagement.Application.Features.Department.Queries.GetAllDepartmentDetails
{
	public class GetAllDepartmentDetailsQuery : IRequest<List<DepartmentDetailVM>>
	{
	}
}
