using HRManagement.Domain.Common;
using HRManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Persistence
{
	public class HRManagementDbContext : DbContext
    {

        public HRManagementDbContext(DbContextOptions<HRManagementDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }        
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HRManagementDbContext).Assembly);

            modelBuilder.Entity<Department>().HasData(new Department
            {
                DepartmentId = 1,
                DepartmentName = "HR"
            });

            modelBuilder.Entity<Department>().HasData(new Department
            {
                DepartmentId = 2,
                DepartmentName = "IT"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                DepartmentId = 2,
                FirstName= "Mahesh",
                LastName = "Patil",
                DateOfBirth = new DateTime(1991,12,5),
                DateOfJoining = new DateTime(2021, 12, 5)
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 2,
                DepartmentId = 1,
                FirstName = "Subha",
                LastName = "Thoroli",
                DateOfBirth = new DateTime(1985, 1, 4),
                DateOfJoining = new DateTime(2020, 11, 5)                       
            });


            modelBuilder.Entity<User>().HasData(new User
            {
                    UserId = 1,
                    FirstName = "Admin",
                    LastName = "Admin",
                    Email = "admin@admin.com"
            });

        }



        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<Entity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedOn = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
