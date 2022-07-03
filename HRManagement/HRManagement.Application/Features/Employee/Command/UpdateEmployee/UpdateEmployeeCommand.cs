using MediatR;
using System;

namespace HRManagement.Application.Features.Employee.Command.UpdateEmployee
{
	public class UpdateEmployeeCommand : IRequest
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateOfJoining { get; set; }

        public int DepartmentId { get; set; }
    }
}
