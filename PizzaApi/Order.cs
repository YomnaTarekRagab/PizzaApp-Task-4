using System.Collections.Generic;

namespace PizzaApp
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
        public List<Pizza> ListOfPizzas { get; set; }
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
}
