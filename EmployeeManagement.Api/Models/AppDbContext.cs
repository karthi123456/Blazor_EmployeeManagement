using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Department Data
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "IT" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 2, DepartmentName = "HR" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 3, DepartmentName = "Admin" });

            //Employee Data
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "Karthi",
                    LastName = "Nagamuthu",
                    Email = "Karthipkm1993@gmail.com",
                    DOB = new DateTime(1993, 11, 16),
                    Gender = Gender.Male,
                    DepartmentId = 1,
                    PhotoPath = "images/karthi.jpg"
                });

            modelBuilder.Entity<Employee>().HasData(
               new Employee
               {
                   EmployeeId = 2,
                   FirstName = "Keerthi",
                   LastName = "Karthi",
                   Email = "Keerthi1999@gmail.com",
                   DOB = new DateTime(1999, 06, 12),
                   Gender = Gender.Female,
                   DepartmentId = 2,
                   PhotoPath = "images/keerthi.jpg"
               });

            modelBuilder.Entity<Employee>().HasData(
               new Employee
               {
                   EmployeeId = 3,
                   FirstName = "Krithik",
                   LastName = "Karthi",
                   Email = "Krithik2021@gmail.com",
                   DOB = new DateTime(2021, 11, 12),
                   Gender = Gender.Male,
                   DepartmentId = 3,
                   PhotoPath = "images/krithik.png"
               });
        }
    }
}