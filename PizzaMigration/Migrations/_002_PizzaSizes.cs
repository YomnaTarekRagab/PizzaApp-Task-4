using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace PizzaMigration.Migrations
{
    [Migration(002)]
    public class _002_PizzaSizes : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("pizza_sizes")
                            .WithIdColumn()
                            .WithNameColumn("type")
                            .WithPriceColumn();
        }
    }
}