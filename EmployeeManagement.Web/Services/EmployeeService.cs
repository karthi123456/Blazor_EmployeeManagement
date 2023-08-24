using Newtonsoft.Json;

using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using EmployeeManagement.Models;

namespace EmployeeManagement.Web.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task<Employee> UpdateEmployee(Employee updatedEmployee);
        Task<Employee> CreateEmployee(Employee newEmployee);
        Task<Employee> DeleteEmployee(int id);
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;
        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await httpClient.GetFromJsonAsync<Employee[]>("api/employees");
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await httpClient.GetFromJsonAsync<Employee>($"api/employees/{id}");
        }

        public async Task<Employee> UpdateEmployee(Employee updatedEmployee)
        {
            HttpResponseMessage httpResponseMessage = 
                        await httpClient.PutAsJsonAsync("api/employees", updatedEmployee);
            var responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
            Employee employee = JsonConvert.DeserializeObject<Employee>(responseContent);

            return employee;
        }

        public async Task<Employee> CreateEmployee(Employee newEmployee)
        {
            HttpResponseMessage httpResponseMessage =
                        await httpClient.PostAsJsonAsync("api/employees", newEmployee);
            var responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
            Employee employee = JsonConvert.DeserializeObject<Employee>(responseContent);

            return employee;
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            return await httpClient.DeleteFromJsonAsync<Employee>($"api/employees/{id}");
        }
    }
}
