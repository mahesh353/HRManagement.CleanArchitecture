using HRManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRManagement.Application.Contracts.Persistence
{
	public interface IEmployeeRepository : IAsyncRepository<Employee>
	{
		Task<List<Employee>> GetAllEmployeesWithDepartments(); 

		Task<List<Employee>> GetEmployeesByNameAsync(string name);

		Task<bool> IsEmployeeNameAndDateOfBirthUnique(string firstName, string lastName, DateTime birthDate);
	}
}
