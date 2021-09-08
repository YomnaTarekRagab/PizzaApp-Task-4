using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PizzaAppRazor.DTOs
{
    public class Order
    {
        private const double _taxes = 15.0;
        private static int _currentId = 0;
        public double TotalPrice { get; set; }
        public int UserId
        {
            get
            {
                return _currentId;
            }
        }
        [Required]
        public Pizza Pizza { get; set; } 
        public Order()
        {
            _currentId++;
        }
  
        public double OrderPrice()
        {
            TotalPrice += this.Pizza.PricePerPizza;
            TotalPrice += _taxes;
            return this.TotalPrice;
        }
    }

    public class Pizza
    {
        public record TypeXPrice(string Type, double Price);
        [Required]
        public double PricePerPizza = 0;
        [Required]
        public TypeXPrice Topping { get; set; }
        [Required]
        public TypeXPrice Size { get; set; }
        [Required]
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

    public record TypeXPrice(string Type, double Price);
    public class PizzaModel
    {
        public List<TypeXPrice> Toppings { get; set; }
        public List<TypeXPrice> Sizes { get; set; }
        public List<TypeXPrice> Sides { get; set; }
    }
}