using HRManagement.Application.Features.Department.Command.CreateDepartment;
using HRManagement.Application.Features.Department.Command.DeleteDepartment;
using HRManagement.Application.Features.Department.Command.UpdateDepartment;
using HRManagement.Application.Features.Department.Queries.GetAllDepartmentDetails;
using HRManagement.Application.Features.Department.Queries.GetDepartmentDetails;
using HRManagement.Application.Features.Department.Queries.GetEmployeesByDepartmentName;
using HRManagement.Application.Features.Employee.Queries.GetEmployeeListByDepartment;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRManagement.API.Controllers
{
	[Route("api/[controller]", Order = 1)]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet(Name = "GetAllDepartments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<DepartmentDetailVM>>> GetAllDepartments()
        {
            var allDepartments = await _mediator.Send(new GetAllDepartmentDetailsQuery());
            return Ok(allDepartments);
        }

		[HttpGet("{id}", Name = "GetDepartmentById")]
		public async Task<ActionResult<DepartmentDetailVM>> GetDepartmentById(int id)
		{
			var getDepartmentDetailQuery = new GetDepartmentDetailQuery() { DepartmentId = id };
			var department = await _mediator.Send(getDepartmentDetailQuery);
			return Ok(department);
		}


		[HttpPost]
		public async Task<ActionResult<int>> Post([FromBody] CreateDepartmentCommand createDepartmentCommand)
		{
			var id = await _mediator.Send(createDepartmentCommand);
			return Ok(id);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> Put([FromBody] UpdateDepartmentCommand updateDepartmentCommand)
		{
			await _mediator.Send(updateDepartmentCommand);
			return NoContent();
		}

		[HttpDelete]
		[Route("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> Delete(int id)
		{
			var deleteDepartmentCommand = new DeleteDepartmentCommand() { DepartmentId = id };
			await _mediator.Send(deleteDepartmentCommand);
			return NoContent();
		}

		[HttpGet("{id:int}/Employees", Name = "GetEmployeesByDepartmentId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<DepartmentEmployeeListVM>>> GetEmployeesByDepartmentId(int id)
        {
            var query = new GetEmployeeListByDepartmentQuery { DepartmentID = id };
            var empList = await _mediator.Send(query);
            return Ok(empList);
        }


		[HttpGet("{name}/Employees", Name = "GetEmployeesByDepartmentName")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<List<DepartmentEmployeeListVM>>> GetEmployeesByDepartmentName(string name)
		{
			var query = new GetEmployeesByDepartmentNameQuery { DepartmentName = name };
			var empList = await _mediator.Send(query);
			return Ok(empList);
		}

	}
}
