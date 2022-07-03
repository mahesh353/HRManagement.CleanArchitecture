using AutoMapper;
using HRManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.Department.Command.CreateDepartment
{
	public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;

        public CreateDepartmentCommandHandler(IMapper mapper, IDepartmentRepository departmentRepository)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }


        public async Task<int> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateDepartmentCommandValidator(_departmentRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);


            var dept = _mapper.Map<Domain.Entities.Department>(request);

            var result = await _departmentRepository.AddAsync(dept);

            return result.DepartmentId;
        }
    }
}
