using System.Collections.Generic;

namespace PizzaApp
{
    public class Pizza
    {
        public record TypeXPrice(string Type, double Price);
        public double PricePerPizza = 0;
        public TypeXPrice Topping { get; set; }
        public TypeXPrice Size { get; set; }
        public TypeXPrice Side { get; set; }
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
