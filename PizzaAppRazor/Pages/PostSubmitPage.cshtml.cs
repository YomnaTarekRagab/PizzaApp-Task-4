using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaAppRazor.Pages
{
    public class PostSubmitPageModel : PageModel
    {
        public IActionResult OnPost()
        {
            return Redirect("/Index");
        }
    }
}