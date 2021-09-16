using System.Collections.Generic;

namespace PizzaApp
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
        public Pizza Pizza { get; set; }
        public Order()
        {
            _currentId++;
        }

        public void SetPizzaOrder(Pizza pizza)
        {
            Pizza = pizza;
            return;
        }

        public double OrderPrice()
        {
            TotalPrice += this.Pizza.PricePerPizza;
            TotalPrice += _taxes;
            return this.TotalPrice;
        }
    }
}
