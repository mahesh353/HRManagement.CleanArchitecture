using AutoMapper;
using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.Department.Command.UpdateDepartment
{
	public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand>
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;

        public UpdateDepartmentCommandHandler(IMapper mapper, IDepartmentRepository departmentRepository)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }

        public async Task<Unit> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var deptToUpdate = await _departmentRepository.GetByIdAsync(request.DepartmentId);

            if (deptToUpdate == null)
            {
                throw new NotFoundException(nameof(Employee), request.DepartmentId);
            }

            var validator = new UpdateDepartmentCommandValidator(_departmentRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);


            _mapper.Map(request, deptToUpdate, typeof(UpdateDepartmentCommand), typeof(Domain.Entities.Department));

            await _departmentRepository.UpdateAsync(deptToUpdate);

            return Unit.Value;
        }
    }
}
