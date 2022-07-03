using AutoMapper;
using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.Employee.Command.DeleteEmployee
{
	public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
    {

        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeCommandHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }


        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.EmployeeId);

            if (employee == null)
            {
                throw new NotFoundException(nameof(Employee), request.EmployeeId);
            }

            await _employeeRepository.DeleteAsync(employee);

            return Unit.Value;
        }
    }
}
