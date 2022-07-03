using AutoMapper;
using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.Employee.Command.UpdateEmployee
{
	public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateEmployeeCommandHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeToUpdate = await _employeeRepository.GetByIdAsync(request.Id);

            if (employeeToUpdate == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }

            var validator = new UpdateEmployeeCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, employeeToUpdate, typeof(UpdateEmployeeCommand), typeof(Domain.Entities.Employee));

            await _employeeRepository.UpdateAsync(employeeToUpdate);

            return Unit.Value;
        }
    }
}
