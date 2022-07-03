using AutoMapper;
using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.Department.Queries.GetDepartmentDetails
{
	public class GetDepartmentDetailsQueryHandler : IRequestHandler<GetDepartmentDetailQuery, DepartmentDetailVM>
    {

        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;

        public GetDepartmentDetailsQueryHandler(IMapper mapper, IDepartmentRepository departmentRepository)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }


        public async Task<DepartmentDetailVM> Handle(GetDepartmentDetailQuery request, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetByIdAsync(request.DepartmentId);

            if (department == null)
            {
                throw new NotFoundException(nameof(Department), request.DepartmentId);
            }

            var depatDetailDto = _mapper.Map<DepartmentDetailVM>(department);

            return depatDetailDto;

        }
    }
}
