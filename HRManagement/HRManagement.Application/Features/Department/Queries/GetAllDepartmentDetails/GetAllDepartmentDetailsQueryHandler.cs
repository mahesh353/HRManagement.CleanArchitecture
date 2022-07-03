using AutoMapper;
using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Features.Department.Queries.GetDepartmentDetails;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.Department.Queries.GetAllDepartmentDetails
{
	public class GetAllDepartmentDetailsQueryHandler : IRequestHandler<GetAllDepartmentDetailsQuery, List<DepartmentDetailVM>>
	{
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;

        public GetAllDepartmentDetailsQueryHandler(IMapper mapper, IDepartmentRepository departmentRepository)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }


        public async Task<List<DepartmentDetailVM>> Handle(GetAllDepartmentDetailsQuery request, CancellationToken cancellationToken)
        {
            var departments = await _departmentRepository.ListAllAsync();
            var departmentDetailList = _mapper.Map<List<DepartmentDetailVM>>(departments);
            return departmentDetailList;
        }

	}
}
