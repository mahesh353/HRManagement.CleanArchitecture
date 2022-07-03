using AutoMapper;
using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Features.Employee.Queries.GetEmployeeDetails;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.Employee.Queries.GetAllEmployees
{
	public class GetAllEmployeeDetailsQueryHandler : IRequestHandler<GetAllEmployeeDetailsQuery, List<EmployeeDetailsVM>>
	{
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public GetAllEmployeeDetailsQueryHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeDetailsVM>> Handle(GetAllEmployeeDetailsQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetAllEmployeesWithDepartments();

            var employeeDetailsVm = _mapper.Map<List<EmployeeDetailsVM>>(employee);

            return employeeDetailsVm;
        }
    }
}
