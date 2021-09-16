using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaAppRazor.DTOs;
using Newtonsoft.Json;
 
namespace PizzaAppRazor.Pages
{
    public class OrderFormModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        public PizzaModel PizzaMenu { get; set; }
        [BindProperty]
        public Pizza PizzaChoice { get; set; }
        public Order PrefOrder { get; set; }
        public string baseUrl = "http://localhost:5000/";

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
        }

        public async Task <IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                @TempData["Message"] = "Sorry, we couldn't place your order";
                @TempData["class-style"] = "danger";
                return Redirect("/PostSubmitPage");
            }
            else
            {
                var client = _clientFactory.CreateClient("PizzaAppApi");
                var jsonPizza = System.Text.Json.JsonSerializer.Serialize<Pizza>(PizzaChoice);
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(baseUrl + "price"),
                    Content = new StringContent(jsonPizza, System.Text.Encoding.UTF8, "application/json"),
                };
                var price = await client.SendAsync(request);
                PrefOrder = new Order
                {
                    Pizza = new Pizza()
                };
                PrefOrder.SetPizzaOrder(PizzaChoice);
                PrefOrder.Pizza.PricePerPizza = Double.Parse(await price.Content.ReadAsStringAsync());
                PrefOrder.OrderPrice();
                var myContent = JsonConvert.SerializeObject(PrefOrder);
                var stringContent = new StringContent(myContent, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync(baseUrl + "createPizza", stringContent);
                if (response.IsSuccessStatusCode)
                {
                    @TempData["Message"] = "Your Order has been created successfully!!";
                    @TempData["class-style"] = "success";
                }
                else
                {
                    @TempData["Message"] = "Sorry, we couldn't place your order";
                    @TempData["class-style"] = "danger";
                }
                return Redirect("/PostSubmitPage");
            }
        }
    }
}