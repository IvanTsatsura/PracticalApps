using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Packt.Shared;

namespace Northwind.Web.Pages
{
    public class ClientsModel : PageModel
    {
        private NorthwindContext _db;
        private string? _selectedName;
        public IEnumerable<Customer>? Customers { get; set; }

        public ClientsModel(NorthwindContext injectContext)
        {
            _db = injectContext;
        }
        public void OnGet()
        {
            ViewData["Title"] = "Northwind B2B - Customers";
            Customers = _db.Customers.OrderBy(c => c.Country);
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("selectedCustomer");
        }
    }
}
