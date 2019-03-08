using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;

namespace EmployeeWebApp.Pages
{
    public class StatusCodeErrorModel : PageModel
    {
        public new int StatusCode { get; set; }
        public string Description { get; set; }

        public void OnGet()
        {
            StatusCode = HttpContext.Response.StatusCode;
            Description = ReasonPhrases.GetReasonPhrase(StatusCode);
        }
    }
}