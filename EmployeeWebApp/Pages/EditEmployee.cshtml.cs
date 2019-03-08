using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EmployeeWebApp.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeWebApp.Pages
{
    public class EditEmployeeModel : PageModel
    {
        private readonly HttpClient _client;

        public EditEmployeeModel(HttpClient client)
        {
            _client = client;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public Employee Input { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            HttpResponseMessage response = await _client.GetAsync($"api/employees/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode);
            }

            Input = await response.Content.ReadAsAsync<Employee>();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await _client.PutAsJsonAsync($"api/employees/edit", Input);

                if (!response.IsSuccessStatusCode)
                {
                    StatusMessage = $"Error: editing employee with id: {Input.Id}";
                }
                else
                {
                    StatusMessage = $"Successfully edited employee with id: {Input.Id}";
                }

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}