using AutoMapper;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EditEmployeeBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        public Employee Employee { get; set; } = new Employee();
        public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();

        [Inject]
        public IDepartmentService DepartmentService { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
            Departments = (await DepartmentService.GetDepartments()).ToList();

            Mapper.Map(Employee, EditEmployeeModel);

            //EditEmployeeModel = new EditEmployeeModel
            //{
            //    EmployeeId = Employee.EmployeeId,
            //    FirstName = Employee.FirstName,
            //    LastName = Employee.LastName,
            //    Email = Employee.Email,
            //    ConfirmEmail = Employee.Email,
            //    DOB = Employee.DOB,
            //    Gender = Employee.Gender,
            //    PhotoPath = Employee.PhotoPath,
            //    DepartmentId = Employee.DepartmentId,
            //    Department = Employee.Department
            //};
        }

        protected void HandleValidSubmit()
        { 
        }
    }
}
