using EmployeeManagement.Models;
using System.Text.Json;

namespace EmployeeManagement.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Employee>> GetEmployee()
        {
            var listofemployees = await httpClient.GetFromJsonAsync<Employee[]>("api/employees");
            //var listofemployees = await httpClient.GetAsync("api/employees");
            return listofemployees ;
        }
    }
}
