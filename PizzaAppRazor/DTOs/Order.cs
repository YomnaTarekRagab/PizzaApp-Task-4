using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PizzaAppRazor.DTOs
{
    public class Order
    {
        private const float _taxes = 15.0f;
        private static int _currentId = 0;
        public float TotalPrice { get; set; }
        //public int NumOfPizzas { get; set; }
        public int UserId
        {
            get
            {
                return _currentId;
            }
        }
        [Required]
        public List<Pizza> ListOfPizzas { get; set; } = new List<Pizza>();
        public Order()
        {
            _currentId++;
        }
        public bool AddPizza(Pizza tobeAddedPizza)
        {
            try
            {
                ListOfPizzas.Add(tobeAddedPizza);
                return true;
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }
        public float OrderPrice()
        {
            foreach (Pizza item in ListOfPizzas)
            {
                TotalPrice += item.CalculatePrice();
            }
            TotalPrice += _taxes;
            return this.TotalPrice;
        }
    }

    public class Pizza
    {
        public record TypeXPrice(string Type, float Price);
        private float _price = 0;
        [Required]
        public TypeXPrice Topping { get; set; }
        [Required]
        public TypeXPrice Size { get; set; }
        [Required]
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

    public record TypeXPrice(string Type, float Price);
    public class PizzaModel
    {
        public List<TypeXPrice> Toppings { get; set; }
        public List<TypeXPrice> Sizes { get; set; }
        public List<TypeXPrice> Sides { get; set; }
    }
}

