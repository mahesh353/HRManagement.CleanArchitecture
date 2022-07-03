using AutoMapper;
using HRManagement.Application.Features.Department.Command.CreateDepartment;
using HRManagement.Application.Features.Department.Command.DeleteDepartment;
using HRManagement.Application.Features.Department.Command.UpdateDepartment;
using HRManagement.Application.Features.Department.Queries.GetDepartmentDetails;
using HRManagement.Application.Features.Employee.Command;
using HRManagement.Application.Features.Employee.Command.DeleteEmployee;
using HRManagement.Application.Features.Employee.Command.UpdateEmployee;
using HRManagement.Application.Features.Employee.Queries.GetEmployeeDetails;
using HRManagement.Application.Features.Employee.Queries.GetEmployeeListByDepartment;
using HRManagement.Domain.Entities;

namespace HRManagement.Application.Profiles
{
	public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, CreateEmployeeCommand>().ReverseMap();
            CreateMap<Employee, DeleteEmployeeCommand>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeCommand>().ReverseMap();
            CreateMap<Employee, EmployeeDetailsVM>();

            CreateMap<Employee, DepartmentEmployeeDto>();
            CreateMap<Department, DepartmentDetailVM>();
            CreateMap<Department, DepartmentVM>().ReverseMap();

            CreateMap<Department, DepartmentEmployeeListVM>();
            CreateMap<Department, UpdateDepartmentCommand>().ReverseMap();
            CreateMap<Department, CreateDepartmentCommand>().ReverseMap();
            CreateMap<Department, DeleteDepartmentCommand>();
            
        }
    }
}
