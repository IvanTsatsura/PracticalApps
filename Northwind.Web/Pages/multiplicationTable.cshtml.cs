using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Northwind.Web.Pages
{
    public class multiplicationTableModel : PageModel
    {
        [BindProperty]
        public int Number { get;  set; }
        public void OnGet()
        {
            ViewData["Title"] = "Multiplication table";
        }

        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
