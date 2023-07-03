using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Northwind.Web.Pages
{
    public class fibonacciSequenceModel : PageModel
    {
        [BindProperty]
        public int? fibonacciCount { get; set; }
        public void OnGet()
        {
            ViewData["Title"] = "Fibonacci sequence";
        }

        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
