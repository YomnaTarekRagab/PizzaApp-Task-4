using System.Collections.Generic;

namespace PizzaAppRazor.Models
{
    public class Pizza
    {
        public record TypeXPrice(string Type, float Price);
        private float _price = 0;
        public TypeXPrice Topping { get; set; }
        public TypeXPrice Size { get; set; }
        public TypeXPrice Side { get; set; }
        public float CalculatePrice()
        {
            if (this._price == 0)
            {
                this._price += this.Topping.Price + this.Size.Price + this.Side.Price;
            }
            return this._price;
        }
    }
}
