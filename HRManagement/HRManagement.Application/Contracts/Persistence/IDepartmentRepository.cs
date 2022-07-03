using HRManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRManagement.Application.Contracts.Persistence
{
	public interface IDepartmentRepository : IAsyncRepository<Department>
    {
        Task<List<Department>> GetEmployeesByDepartment(int departmentId);

        Task<List<Department>> GetEmployeesByDepartmentName(string departmentName);

        Task<bool> IsDepartmentNameUnique(int departmentId,string departmentName);
    }
}
