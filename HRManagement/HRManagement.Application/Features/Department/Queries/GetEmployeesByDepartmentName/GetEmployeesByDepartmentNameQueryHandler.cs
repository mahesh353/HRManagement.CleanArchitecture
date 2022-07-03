using AutoMapper;
using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Exceptions;
using HRManagement.Application.Features.Employee.Queries.GetEmployeeListByDepartment;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.Department.Queries.GetEmployeesByDepartmentName
{
	public class GetEmployeesByDepartmentNameQueryHandler :  IRequestHandler<GetEmployeesByDepartmentNameQuery, List<DepartmentEmployeeListVM>>
	{
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;

        public GetEmployeesByDepartmentNameQueryHandler(IMapper mapper, IDepartmentRepository departmentRepository)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;

        }

        public async Task<List<DepartmentEmployeeListVM>> Handle(GetEmployeesByDepartmentNameQuery request, CancellationToken cancellationToken)
        {
            var list = await _departmentRepository.GetEmployeesByDepartmentName(request.DepartmentName);

            if (list == null || list.Count == 0)
            {
                throw new NotFoundException(nameof(Employee), request.DepartmentName);
            }

            return _mapper.Map<List<DepartmentEmployeeListVM>>(list);

        }
    }
}
