using AutoMapper;
using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Features.Employee.Command.CreateEmployee;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.Employee.Command
{
	class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
    {

        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeCommandHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEmployeeCommandValidator(_employeeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var employee = _mapper.Map<Domain.Entities.Employee>(request);

            var result = await _employeeRepository.AddAsync(employee);

            return result.EmployeeId;
        }
    }
}
