using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace PizzaMigration.Migrations
{
    [Migration(005)]
    public class _005_Pizza : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("pizzas_list")
                            .WithIdColumn().Indexed()
                            .WithColumn("order_id").AsInt32().NotNullable().ForeignKey("orders_list", "id").PrimaryKey()
                            .WithColumn("topping").AsString().NotNullable().ForeignKey("pizza_toppings", "type")
                            .WithColumn("size").AsString().NotNullable().ForeignKey("pizza_sizes", "type")
                            .WithColumn("side").AsString().NotNullable().ForeignKey("pizza_sides", "type")
                            .WithColumn("price_per_pizza").AsDouble().NotNullable();
        }
    }
}