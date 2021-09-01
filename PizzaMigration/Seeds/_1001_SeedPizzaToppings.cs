using FluentMigrator;
using System.Collections.Generic;

namespace PizzaMigration.Seeds
{
    public class PizzaToppings
    {
        public string Type { get; set; }
        public double Price { get; set; }
    }

    [Migration(1001)]
    public class _1001_SeedPizzaToppings : AutoReversingMigration
    {
        public static List<PizzaToppings> PizzaTopping = new()
        {
            new() { Type = "Chicken BBQ", Price = 15 },
            new() { Type = "Shrimps", Price = 30 },
            new() { Type = "Pepperoni", Price = 12.5 },
            new() { Type = "Vegetables", Price = 8.4 },
            new() { Type = "Meat", Price = 17.5 },
        };

        public override void Up()
        {
            foreach (var topping in PizzaTopping)
            {
                Insert.IntoTable("pizza_toppings").Row(
                    new
                    {
                        type = topping.Type,
                        price = topping.Price
                    });
            }
        }
    }
}