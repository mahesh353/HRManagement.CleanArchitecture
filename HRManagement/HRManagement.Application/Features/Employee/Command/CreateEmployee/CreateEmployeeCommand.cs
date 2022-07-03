using MediatR;
using System;

namespace HRManagement.Application.Features.Employee.Command
{
	public class CreateEmployeeCommand : IRequest<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateOfJoining { get; set; }

        public int DepartmentId { get; set; }
    }
}
