using Microsoft.AspNetCore.Components;

using System.Threading.Tasks;

namespace EmployeeManagement.Components
{
    public class ConfirmBase : ComponentBase
    {
        protected bool ShowConfirmation { get; set; } = false;
        public void Show()
        {
            ShowConfirmation = true;
            StateHasChanged();
        }

        [Parameter]
        public EventCallback<bool> ConfirmationChanged { get; set; }
        [Parameter]
        public string ModalTitle { get; set; }
        
        [Parameter]
        public string ModalBody { get; set; }

        protected async Task OnConfirmationChange(bool value)
        {
            ShowConfirmation = false;
            await ConfirmationChanged.InvokeAsync(value);
        }
    }
}
