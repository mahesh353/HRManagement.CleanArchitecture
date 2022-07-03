using AutoMapper;
using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.Employee.Queries.GetEmployeeDetails
{
	public class GetEmployeeDetailsQueryHandler : IRequestHandler<GetEmployeeDetailsQuery, EmployeeDetailsVM>
	{
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public GetEmployeeDetailsQueryHandler(IMapper mapper, IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<EmployeeDetailsVM> Handle(GetEmployeeDetailsQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.EmployeeId);

            if (employee == null)
            {
                throw new NotFoundException(nameof(Employee), request.EmployeeId);
            }

            var department = await _departmentRepository.GetByIdAsync(employee.DepartmentId);

            var employeeDetailsVm = _mapper.Map<EmployeeDetailsVM>(employee);

            employeeDetailsVm.Department = _mapper.Map<DepartmentVM>(department);

            return employeeDetailsVm;

        }
    }
}
