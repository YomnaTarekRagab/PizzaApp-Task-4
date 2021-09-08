using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace PizzaMigration.Migrations
{
    [Migration(004)]
    public class _004_Orders : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("orders_list")
                            .WithIdColumn()
                            .WithColumn("total_price").AsDouble().NotNullable();
        }
    }
}
