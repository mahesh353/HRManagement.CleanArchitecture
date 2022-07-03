using HRManagement.Application.Contracts.Persistence;
using HRManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.Persistence.Repositories
{
	public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
	{
		public EmployeeRepository(HRManagementDbContext dbContext) : base(dbContext)
		{
		}

		public async Task<List<Employee>> GetAllEmployeesWithDepartments()
		{
			var allEmployees = await _dbContext.Employees.Include(x => x.Department).ToListAsync();

			return allEmployees;
		}

		public async Task<List<Employee>> GetEmployeesByNameAsync(string name)
		{
			var employee = await _dbContext.Employees.Where(employee => employee.FirstName.Contains(name)).Include(x => x.Department).ToListAsync();

			return employee;
		}

		public Task<bool> IsEmployeeNameAndDateOfBirthUnique(string firstName, string lastName, DateTime birthDate)
		{
			var matches = _dbContext.Employees.Any(e => e.FirstName.Equals(firstName) && e.LastName.Equals(lastName) && e.DateOfBirth.Equals(birthDate));
			return Task.FromResult(matches);
		}
	}
}
