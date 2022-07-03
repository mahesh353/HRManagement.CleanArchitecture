using HRManagement.Application.Features.Employee.Command;
using HRManagement.Application.Features.Employee.Command.DeleteEmployee;
using HRManagement.Application.Features.Employee.Command.UpdateEmployee;
using HRManagement.Application.Features.Employee.Queries.GetAllEmployees;
using HRManagement.Application.Features.Employee.Queries.GetEmployeeDetails;
using HRManagement.Application.Features.Employee.Queries.GetEmployeeDetailsByName;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRManagement.API.Controllers
{
	[Route("api/[controller]", Order = 1)]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly IMediator _mediator;

		public EmployeeController(IMediator mediator)
		{
			this._mediator = mediator;
		}

		[HttpGet(Name = "GetAllEmployees")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<List<EmployeeDetailsVM>>> GetAllEmployees()
		{
			var employeeDetailsList = await _mediator.Send(new GetAllEmployeeDetailsQuery());
			return Ok(employeeDetailsList);
		}

		[HttpGet("{id}", Name = "GetEmployeeById")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<EmployeeDetailsVM>> GetEmployeeById(int id)
		{
			var query = new GetEmployeeDetailsQuery { EmployeeId = id };
			var empList = await _mediator.Send(query);
			return Ok(empList);
		}


		[HttpPost]
		public async Task<ActionResult<int>> Post([FromBody] CreateEmployeeCommand createEmployeeCommand)
		{
			var id = await _mediator.Send(createEmployeeCommand);
			return Ok(id);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> Put([FromBody] UpdateEmployeeCommand updateEmployeeommand)
		{
			await _mediator.Send(updateEmployeeommand);
			return NoContent();
		}

		[HttpDelete]
		[Route("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> Delete(int id)
		{
			var deleteEemployeeCommand = new DeleteEmployeeCommand() { EmployeeId = id };
			await _mediator.Send(deleteEemployeeCommand);
			return NoContent();
		}

		[HttpGet("GetEmployeeByName/{name}", Name = "GetEmployeeByName")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<EmployeeDetailsVM>> GetEmployeeByName(string name)
		{
			var query = new GetEmployeeDetailsByNameQuery { Name = name };
			var empList = await _mediator.Send(query);
			return Ok(empList);
		}

	}
}
