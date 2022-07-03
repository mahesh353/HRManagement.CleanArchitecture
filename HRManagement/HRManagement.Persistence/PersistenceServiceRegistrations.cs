using HRManagement.Application.Contracts.Persistence;
using HRManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace HRManagement.Persistence
{
    public static class PersistenceServiceRegistrations
    {
        public static IServiceCollection AddPresistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HRManagementDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("HRManagementConnectionString")));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            
            return services;
        }

    }
}
