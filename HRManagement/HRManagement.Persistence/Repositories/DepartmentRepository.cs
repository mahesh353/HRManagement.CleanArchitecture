using HRManagement.Application.Contracts.Persistence;
using HRManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.Persistence.Repositories
{
	public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
	{

		public DepartmentRepository(HRManagementDbContext dbContext) : base(dbContext)
		{
		}

		public async Task<List<Department>> GetEmployeesByDepartment(int deptId)
		{
			var allEmployees = await _dbContext.Departments.Where(m => m.DepartmentId == deptId)
				.Include(x => x.Employees).ToListAsync();

			return allEmployees;
		}

		public async Task<List<Department>> GetEmployeesByDepartmentName(string departmentName)
		{
			var allEmployees = await _dbContext.Departments.Where(m => m.DepartmentName.Contains(departmentName))
			   .Include(x => x.Employees).ToListAsync();

			return allEmployees;
		}

		public Task<bool> IsDepartmentNameUnique(int departmentId, string departmentName)
		{
			var matches = _dbContext.Departments.Any(e => e.DepartmentName.Equals(departmentName) && !e.DepartmentId.Equals(departmentId));
			return Task.FromResult(matches);
		}
	}
}
