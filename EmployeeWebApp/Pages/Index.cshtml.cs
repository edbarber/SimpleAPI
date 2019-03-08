using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;

namespace EmployeeWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _client;

        public IndexModel(HttpClient client)
        {
            _client = client;
        }

        [TempData]
        public string StatusMessage { get; set; } 

        public List<Employee> Employees { get; set; }

        public async Task OnGetAsync()
        {
            HttpResponseMessage response = await _client.GetAsync("api/employees");
            Employees = await response.Content.ReadAsAsync<List<Employee>>();
        }

        public async Task OnPostDeleteEmployeeAsync(string id)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"api/employees/delete/{id}");

            if (response.IsSuccessStatusCode)
            {
                StatusMessage = $"Successfully deleted employee with id: {id}";
            }
            else
            {
                StatusMessage = $"Error: Failed to delete employee with id: {id}";
            }
        }
    }
}