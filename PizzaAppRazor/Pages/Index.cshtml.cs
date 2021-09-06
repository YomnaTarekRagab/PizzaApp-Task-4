using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaAppRazor.Pages;
using PizzaAppRazor.Models;
using System.Net.Http;

namespace PizzaAppRazor.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty, TempData]
        public int NumOfPizzasOrder { get; set; }

        public IActionResult OnPost()
        {
            NumOfPizzasOrder = Convert.ToInt32(Request.Form["NumOfPizzasOrder"]);
            TempData["NumberOfPizzas"] = NumOfPizzasOrder;
            TempData.Peek("NumberOfPizzas");
            TempData.Keep("NumberOfPizzas");
            Console.WriteLine($"From the Index page:{NumOfPizzasOrder}");
            return RedirectToPage("/OrderForm");
        }
    }
}
