using AutoMapper;
using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Exceptions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.Employee.Queries.GetEmployeeListByDepartment
{
	public class GetEmployeeListByDepartmentQueryHandler : IRequestHandler<GetEmployeeListByDepartmentQuery, List<DepartmentEmployeeListVM>>
    {

        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _deptRepository;

        public GetEmployeeListByDepartmentQueryHandler(IMapper mapper, IDepartmentRepository deptRepository)
        {
            _mapper = mapper;
            _deptRepository = deptRepository;

        }

        public async Task<List<DepartmentEmployeeListVM>> Handle(GetEmployeeListByDepartmentQuery request, CancellationToken cancellationToken)
        {
            var list = await _deptRepository.GetEmployeesByDepartment(request.DepartmentID);

            if (list == null || list.Count == 0)
            {
                throw new NotFoundException(nameof(Department), request.DepartmentID);
            }

            return _mapper.Map<List<DepartmentEmployeeListVM>>(list);
            
        }
    }
}
