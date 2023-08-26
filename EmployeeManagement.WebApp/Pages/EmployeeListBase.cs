using EmployeeManagement.Models;
using EmployeeManagement.WebApp.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.WebApp.Pages
{
    public partial class EmployeeListBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        public bool ShowFooter { get; set; } = true;
        public IEnumerable<Employee> Employees { get; set; }
        protected int SelectEmployeesCount { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employees = (await EmployeeService.GetEmployees()).ToList();

            //await Task.Run(() => LoadEmployees());
        }

        protected async Task EmployeeDeleted()
        { 
            Employees = (await EmployeeService.GetEmployees()).ToList();
        }
        protected void EmployeeSelectionChanged(bool isSelected)
        {
            if (isSelected)
            {
                SelectEmployeesCount++;
            }
            else
            {
                SelectEmployeesCount--;
            }
        }

        //HardCode Data
        private void LoadEmployees()
        {
            System.Threading.Thread.Sleep(2000);
            Employee e1 = new Employee
            {
                EmployeeId = 1,
                FirstName = "Karthi",
                LastName = "Nagamuthu",
                Email = "Karthipkm1993@gmail.com",
                DOB = new DateTime(1993, 11, 16),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/karthi.jpg"
            };

            Employee e2 = new Employee
            {
                EmployeeId = 2,
                FirstName = "Keerthi",
                LastName = "Karthi",
                Email = "Keerthi1999@gmail.com",
                DOB = new DateTime(1999, 06, 12),
                Gender = Gender.Male,
                DepartmentId = 2,
                PhotoPath = "images/keerthi.jpg"
            };

            Employee e3 = new Employee
            {
                EmployeeId = 3,
                FirstName = "Krithik",
                LastName = "Karthi",
                Email = "Krithik2021@gmail.com",
                DOB = new DateTime(2021, 11, 12),
                Gender = Gender.Male,
                DepartmentId = 3,
                PhotoPath = "images/krithik.png"
            };

            Employees = new List<Employee> { e1, e2, e3 };
        }
    }
}
