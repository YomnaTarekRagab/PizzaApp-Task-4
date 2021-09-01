using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace PizzaMigration.Migrations
{
    [Migration(003)]
    public class _003_PizzaSides : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("pizza_sides")
                            .WithIdColumn()
                            .WithNameColumn("type")
                            .WithPriceColumn();
        }
    }
}