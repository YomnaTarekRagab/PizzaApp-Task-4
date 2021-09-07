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
        public Order PrefOrder { get; set; } = new Order();
        [BindProperty]
        public Pizza SinglePizza { get; set; } = new Pizza ();
       
        public OrderFormModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            
        }

        public async Task OnGet()
        {
            //Console.WriteLine($"hello:{ TempData["NumOfPizzasOrder"]}");
            //var num = JsonConvert.DeserializeObject<string>(TempData["NumOfPizzasOrder"].ToString());
            //NumOfPizzasForm = Convert.ToInt32(num);
            //PrefOrder.NumOfPizzas =NumOfPizzasForm;
            var request = new HttpRequestMessage(HttpMethod.Get, "/components");
            var client = _clientFactory.CreateClient("PizzaAppApi");
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var serializedResponse = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                PizzaMenu = System.Text.Json.JsonSerializer.Deserialize<PizzaModel>(serializedResponse, options);
            }
        }

       
        //public void AddPizzaToOrder()
        //{
        //    PrefOrder.AddPizza(this.SinglePizza);
        //    Console.WriteLine($"Lists:{PrefOrder.ListOfPizzas}");

        //}

        public async Task <IActionResult> OnPost()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/createPizza");
            request.Headers.Add("Accept", "application/json");
            request.Content = new StringContent(JsonConvert.SerializeObject(PrefOrder), System.Text.Encoding.UTF8, "application/json");
            var client = _clientFactory.CreateClient("PizzaAppApi");
            var response = await client.SendAsync(request);
            return RedirectToPage("/Index");
        }


    }

}