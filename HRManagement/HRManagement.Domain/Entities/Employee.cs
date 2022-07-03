using HRManagement.Domain.Common;
using System;

namespace HRManagement.Domain.Entities
{
	public class Employee : Entity
    {

        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateOfJoining { get; set; }

        public int DepartmentId { get; set; } 
        
        public Department Department { get; set; }

    }
}
