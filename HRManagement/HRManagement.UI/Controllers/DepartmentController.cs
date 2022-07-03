using HRManagement.Application.Features.Department.Command.CreateDepartment;
using HRManagement.Application.Features.Department.Command.UpdateDepartment;
using HRManagement.Application.Features.Department.Queries.GetDepartmentDetails;
using HRManagement.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HRManagement.UI.Controllers
{
	[Route("[controller]/[action]", Order = 0)]
	public class DepartmentController : Controller
	{
		const string API_URL = "http://localhost:64879/api/Department";
		private readonly ILogger<DepartmentController> _logger;

		public DepartmentController(ILogger<DepartmentController> logger)
		{
			_logger = logger;
		}

		public async Task<IActionResult> Index()
		{
			var departmentList = new List<DepartmentDetailVM>();
			using (var httpClient = new HttpClient())
			{
				using (var response = await httpClient.GetAsync($"{API_URL}"))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					departmentList = JsonConvert.DeserializeObject<List<DepartmentDetailVM>>(apiResponse);
				}
			}

			return View(departmentList);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(DepartmentViewModel departmentViewModel)
		{
			if (ModelState.IsValid)
			{
				var createDepartmentCommand = new CreateDepartmentCommand
				{
					DepartmentName = departmentViewModel.DepartmentName,
				};

				using (var httpClient = new HttpClient())
				{
					//StringContent content = new StringContent(JsonConvert.SerializeObject(createEmployeeCommand), Encoding.UTF8, "application/json");

					using (var response = await httpClient.PostAsJsonAsync($"{API_URL}", createDepartmentCommand))
					{
						if (!response.IsSuccessStatusCode)
						{
							ModelState.AddModelError("DepartmentName", $"Department {createDepartmentCommand.DepartmentName} already present in the database.");

							return View();
						}
						else
						{
							return RedirectToAction("Index");
						}
					}
				}
			}

			return View();
		}

		public async Task<IActionResult> Edit(int id)
		{
			var departmentDetailVM = new DepartmentDetailVM();

			using (var httpClient = new HttpClient())
			{
				using (var response = await httpClient.GetAsync($"{API_URL}/{id}")) 
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					departmentDetailVM = JsonConvert.DeserializeObject<DepartmentDetailVM>(apiResponse);
				}
			}
			return View(departmentDetailVM);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(DepartmentDetailVM departmentDetailVM)
		{
			if (ModelState.IsValid)
			{
				using (var httpClient = new HttpClient())
				{
					var updateDepartmentCommand = new UpdateDepartmentCommand() 
					{
						DepartmentName = departmentDetailVM.DepartmentName,
						DepartmentId = departmentDetailVM.DepartmentId
					};
					using (var response = await httpClient.PutAsJsonAsync($"{API_URL}", updateDepartmentCommand))
					{
						if (!response.IsSuccessStatusCode)
						{
							ModelState.AddModelError("DepartmentName", $"Department {updateDepartmentCommand.DepartmentName} already present in the database.");
							return View();
						}
						else
						{
							return RedirectToAction("Index");
						}
					}
				}

			}
			return View();
		}

		public async Task<IActionResult> Details(int id)
		{
			var departmentDetailVM = new DepartmentDetailVM();

			using (var httpClient = new HttpClient())
			{
				using (var response = await httpClient.GetAsync($"{API_URL}/{id}"))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					departmentDetailVM = JsonConvert.DeserializeObject<DepartmentDetailVM>(apiResponse);
				}
			}
			return View(departmentDetailVM);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int DepartmentId)
		{
			using (var httpClient = new HttpClient())
			{
				using (var response = await httpClient.DeleteAsync($"{API_URL}/{DepartmentId}"))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
				}
			}

			return RedirectToAction("Index");
		}

		public IActionResult Report()
		{
			return View();
		}

	}

}
