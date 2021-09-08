using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PizzaAppRazor.Pages
{
    public class IndexModel : PageModel
    {
        public IActionResult OnPost()
        {
            return RedirectToPage("/OrderForm");
        }
    }
}