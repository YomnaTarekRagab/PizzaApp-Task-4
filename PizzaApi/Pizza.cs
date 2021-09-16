using System.Collections.Generic;

namespace PizzaApp
{
    public class Pizza
    {
        public record TypeXPrice(string Type, double Price);
        public double PricePerPizza { get; set; }
        public string Topping { get; set; }
        public string Size { get; set; }
        public string Side { get; set; }
        public double CalculatePrice(double topPrice, double sizePrice, double sidePrice)
        {
            if (this.PricePerPizza == 0)
            {
                this.PricePerPizza = topPrice + sizePrice + sidePrice;
            }
            return this.PricePerPizza;
        }
    }
}
