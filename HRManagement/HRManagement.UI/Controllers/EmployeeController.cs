using HRManagement.Application.Features.Department.Queries.GetDepartmentDetails;
using HRManagement.Application.Features.Employee.Command;
using HRManagement.Application.Features.Employee.Command.UpdateEmployee;
using HRManagement.Application.Features.Employee.Queries.GetEmployeeDetails;
using HRManagement.UI.Service;
using HRManagement.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.UI.Controllers
{
	[Route("[controller]/[action]", Order = 0)]
	public class EmployeeController : Controller
	{
		const string API_URL = "http://localhost:64879/api/Employee";
		const string DEPT_API_URL = "http://localhost:64879/api/Department";

		private readonly ILogger<EmployeeController> _logger;

		public EmployeeController(ILogger<EmployeeController> logger)
		{
			_logger = logger;
		}

		public async Task<IActionResult> Index()
		{
			var employeesList = new List<EmployeeDetailsVM>();
			using (var httpClient = new HttpClient())
			{
				using (var response = await httpClient.GetAsync($"{API_URL}"))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					employeesList = JsonConvert.DeserializeObject<List<EmployeeDetailsVM>>(apiResponse);
				}
			}

			return View(employeesList);
		}

		public async Task<IActionResult> Create()
		{
			var employeeViewModel = new EmployeeViewModel();
			using (var httpClient = new HttpClient())
			{
				using (var response = await httpClient.GetAsync($"{DEPT_API_URL}"))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					employeeViewModel.Departments = JsonConvert.DeserializeObject<List<DepartmentDetailVM>>(apiResponse);
				}
			}
			return View(employeeViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Create(EmployeeViewModel employeeViewModel)
		{
			if (ModelState.IsValid)
			{
				var createEmployeeCommand = new CreateEmployeeCommand
				{
					FirstName = employeeViewModel.FirstName,
					LastName = employeeViewModel.LastName,
					DateOfBirth = employeeViewModel.DateOfBirth.Value,
					DateOfJoining = employeeViewModel.DateOfJoining.Value,
					DepartmentId = employeeViewModel.DepartmentId
				};

				using (var httpClient = new HttpClient())
				{
					using (var response = await httpClient.PostAsJsonAsync($"{API_URL}", createEmployeeCommand))
					{
						string apiResponse = await response.Content.ReadAsStringAsync();
					}
				}
				return RedirectToAction("Index");
			}

			return View();
		}

		public async Task<IActionResult> Edit(int id)
		{
			var editEmployeeViewModel = new EditEmployeeViewModel();

			using (var httpClient = new HttpClient())
			{
				using (var response = await httpClient.GetAsync($"{API_URL}/{id}"))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					editEmployeeViewModel = JsonConvert.DeserializeObject<EditEmployeeViewModel>(apiResponse);
				}
			}
			return View(editEmployeeViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(EmployeeDetailsVM employeeDetailsVM)
		{
			if (ModelState.IsValid)
			{
				using (var httpClient = new HttpClient())
				{
					var updateEmployeeCommand = new UpdateEmployeeCommand()
					{
						Id = employeeDetailsVM.EmployeeId,
						FirstName = employeeDetailsVM.FirstName,
						LastName = employeeDetailsVM.LastName,
						DateOfBirth = employeeDetailsVM.DateOfBirth,
						DateOfJoining = employeeDetailsVM.DateOfJoining,
						DepartmentId = employeeDetailsVM.EmployeeId
					};
					using (var response = await httpClient.PutAsJsonAsync($"{API_URL}", updateEmployeeCommand))
					{
						string apiResponse = await response.Content.ReadAsStringAsync();
						ViewBag.Result = "Success";
					}
				}

				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> Details(int id)
		{
			var editEmployeeViewModel = new EditEmployeeViewModel();

			using (var httpClient = new HttpClient())
			{
				using (var response = await httpClient.GetAsync($"{API_URL}/{id}"))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					editEmployeeViewModel = JsonConvert.DeserializeObject<EditEmployeeViewModel>(apiResponse);
				}
			}
			return View(editEmployeeViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int EmployeeId)
		{
			using (var httpClient = new HttpClient())
			{
				using (var response = await httpClient.DeleteAsync($"{API_URL}/{EmployeeId}"))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
				}
			}

			return RedirectToAction("Index");
		}
	}
}
