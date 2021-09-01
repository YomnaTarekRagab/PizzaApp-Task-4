using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace PizzaMigration.Migrations
{
    [Migration(001)]
    public class _001_PizzaToppings : AutoReversingMigration 
    {
        public override void Up()
        {
            Create.Table("pizza_toppings")
                            .WithIdColumn()
                            .WithNameColumn("type")
                            .WithPriceColumn();
        }
    }
}