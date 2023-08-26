using Microsoft.AspNetCore.Components;

using System.Threading.Tasks;

using EmployeeManagement.Models;
using EmployeeManagement.WebApp.Services;


namespace EmployeeManagement.WebApp.Pages
{
    public class DisplayEmployeeBase : ComponentBase
    {
        [Parameter]
        public Employee Employee { get; set; }

        [Parameter]
        public bool ShowFooter { get; set; }

        [Parameter]
        public EventCallback<bool> OnEmployeeSelection { get; set; }

        [Parameter]
        public EventCallback<int> OnEmployeeDeleted { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Inject]
        public NavigationManager NavManager { get; set; }

        protected async void CheckBoxChanged(ChangeEventArgs e)
        {
            await OnEmployeeSelection.InvokeAsync((bool)e.Value);
        }

        protected Components.ConfirmBase DeleteConfirmation { get; set; }

        protected async Task Confirm_Delete_Click(bool isDeleteConfirmation)
        {
            if (isDeleteConfirmation)
            {
                await EmployeeService.DeleteEmployee(Employee.EmployeeId);
                await OnEmployeeDeleted.InvokeAsync(Employee.EmployeeId);
            }
        }

        protected void Delete_Click()
        {
            DeleteConfirmation.Show();
        }
    }
}
