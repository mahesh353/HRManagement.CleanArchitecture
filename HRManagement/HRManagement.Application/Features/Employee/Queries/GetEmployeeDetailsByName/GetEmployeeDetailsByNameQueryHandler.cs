using AutoMapper;
using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Exceptions;
using HRManagement.Application.Features.Employee.Queries.GetEmployeeDetails;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.Employee.Queries.GetEmployeeDetailsByName
{
	public class GetEmployeeDetailsByNameQueryHandler : IRequestHandler<GetEmployeeDetailsByNameQuery, List<EmployeeDetailsVM>>
	{
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        
        public GetEmployeeDetailsByNameQueryHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeDetailsVM>> Handle(GetEmployeeDetailsByNameQuery request, CancellationToken cancellationToken)
        {
           
            var employees = await _employeeRepository.GetEmployeesByNameAsync(request.Name);

            if (employees == null)
            {
                throw new NotFoundException(nameof(Employee), request.Name);
            }

            var employeeDetailsVm = _mapper.Map<List<EmployeeDetailsVM>>(employees);

            return employeeDetailsVm;

        }
    }
}
