using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class DataBindingDemoBase : ComponentBase
    {
        public string Name { get; set; } = "Karthi";
        public string Gender { get; set; } = "Male";
        protected string Colour { get; set; } = "background-color:white";
        public string Description { get; set; } = string.Empty;
    }
}
