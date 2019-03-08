using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EmployeeWebApp.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeWebApp.Pages
{
    public class AddEmployeeModel : PageModel
    {
        private readonly HttpClient _client;

        public AddEmployeeModel(HttpClient client)
        {
            _client = client;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public Employee Input { get; set; }

        public void OnGet()
        {
            Input = new Employee();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await _client.PostAsJsonAsync("api/employees/add", Input);

                if (response.IsSuccessStatusCode)
                {
                    Employee createdEmployee = await response.Content.ReadAsAsync<Employee>();
                    StatusMessage = $"Successfully added employee with id: {createdEmployee.Id}";
                }
                else
                {
                    StatusMessage = $"Error: failed to add employee";
                }

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}