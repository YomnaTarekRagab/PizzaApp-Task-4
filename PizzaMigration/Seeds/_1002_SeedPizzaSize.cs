using FluentMigrator;
using System.Collections.Generic;

namespace PizzaMigration.Seeds
{
    public class PizzaSizes
    {
        public string Type { get; set; }
        public double Price { get; set; }
    }

    [Migration(1002)]
    public class _1002_SeedPizzaSize : AutoReversingMigration
    {
        public static List<PizzaSizes> PizzaSize = new()
        {
            new() { Type = "Small", Price = 10 },
            new() { Type = "Medium", Price = 15 },
            new() { Type = "Large", Price = 20 },
        };

        public override void Up()
        {
            foreach (var size in PizzaSize)
            {
                Insert.IntoTable("pizza_sizes").Row(
                    new
                    {
                        type = size.Type,
                        price = size.Price
                    });
            }
        }
    }
}