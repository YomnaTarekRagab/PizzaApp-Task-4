using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaAppRazor.DTOs;
using PizzaAppRazor.Pages;
using Newtonsoft.Json;
 
namespace PizzaAppRazor.Pages
{
    public class OrderFormModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        public PizzaModel PizzaMenu { get; set; }
        [BindProperty]
        public Order PrefOrder { get; set; }
        public string baseUrl = "http://localhost:5000/";
        public static List<TypeXPrice> Toppings { get; set; } = new List<TypeXPrice>();
        public static List<TypeXPrice> Sizes { get; set; } = new List<TypeXPrice>();
        public static List<TypeXPrice> Sides { get; set; } = new List<TypeXPrice>();
        public double toppingPrice = 0.0;
        public double sizePrice = 0.0;
        public double sidePrice = 0.0;

        public OrderFormModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task OnGetAsync()
        {
            var client = _clientFactory.CreateClient("PizzaAppApi");
            string components = await client.GetStringAsync(baseUrl + "components");
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            PizzaMenu = System.Text.Json.JsonSerializer.Deserialize<PizzaModel>(components, options);
            foreach (var item in PizzaMenu.Toppings)
            {
                Toppings.Add(item);
            }
            foreach (var item in PizzaMenu.Sizes)
            {
                Sizes.Add(item);
            }
            foreach (var item in PizzaMenu.Sides)
            {
                Sides.Add(item);
            }
        }

        public void SetPriceForEachType()
        {
            foreach (var item in Toppings)
            {
                if (item.Type == this.PrefOrder.Pizza.Topping.Type)
                {
                    toppingPrice = item.Price;
                }
            }
            foreach (var item in Sizes)
            {
                if (item.Type == this.PrefOrder.Pizza.Size.Type)
                {
                    sizePrice = item.Price;
                }
            }
            foreach (var item in Sides)
            {
                if (item.Type == this.PrefOrder.Pizza.Side.Type)
                {
                    sidePrice = item.Price;
                }
            }
        }

        public async Task <IActionResult> OnPostAsync()
        {
            SetPriceForEachType();
            PrefOrder.Pizza.CalculatePrice(toppingPrice,sizePrice,sidePrice);
            PrefOrder.OrderPrice();
            var myContent = JsonConvert.SerializeObject(PrefOrder);
            var client = _clientFactory.CreateClient("PizzaAppApi");
            var stringContent = new StringContent(myContent, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync(baseUrl + "createPizza", stringContent);
            //if (response.IsSuccessStatusCode)
            //{
     
            //}
            return RedirectToPage("/Index");
        }
    }
}