using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using PizzaApp;
using System.Data;
using PizzaAppData.DatabaseSpecific;
using PizzaAppData.Linq;
using Npgsql;
using SD.LLBLGen.Pro.DQE.PostgreSql;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.LinqSupportClasses;
using System.Linq;
using PizzaAppData.EntityClasses;

var app = WebApplication.Create();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

LLBLGen();

app.MapGet("/components", async () =>
{
    using var adapter = new DataAccessAdapter();
    var metaData = new LinqMetaData(adapter);
    var toppings = await metaData.PizzaTopping.ToListAsync();
    var sizes = await metaData.PizzaSize.ToListAsync();
    var sides = await metaData.PizzaSide.ToListAsync();
    return new
    {
        Toppings = toppings.Select(x => new { x.Id, x.Type, x.Price }),
        Sizes = sizes.Select(x => new { x.Id, x.Type, x.Price }),
        Sides = sides.Select(x => new { x.Id, x.Type, x.Price })
    };
});

app.MapGet("/price", async([FromBody] Pizza pizza) => 
{
    double sum = 0;
    using var adapter = new DataAccessAdapter();
    var metaData = new LinqMetaData(adapter);
    var toppings = await metaData.PizzaTopping.ToListAsync();
    var sizes = await metaData.PizzaSize.ToListAsync();
    var sides = await metaData.PizzaSide.ToListAsync();
    double toppingPrice = 0.0;
    double sidePrice = 0.0;
    double sizePrice = 0.0;
    foreach (var item in toppings)
    {
        if (item.Type == pizza.Topping)
        {
            toppingPrice = item.Price;
        }
    }
    foreach (var item in sizes)
    {
        if (item.Type == pizza.Size)
        {
            sizePrice = item.Price;
        }
    }
    foreach (var item in sides)
    {
        if (item.Type == pizza.Side)
        {
            sidePrice = item.Price;
        }
    }
    sum = pizza.CalculatePrice(toppingPrice, sizePrice, sidePrice);
    return sum;
});

app.MapPost("/createPizza", async([FromBody] Order receivedOrder) =>
{
    using var adapter = new DataAccessAdapter();
    var metaData = new LinqMetaData(adapter);
    adapter.StartTransaction(IsolationLevel.ReadCommitted, "MultiEntityInsertion");
    OrdersListEntity orderRow = new OrdersListEntity();
    orderRow.Id = receivedOrder.UserId;
    var orderId = orderRow.Id;
    orderRow.TotalPrice = receivedOrder.TotalPrice;
    await adapter.SaveEntityAsync(orderRow, true);
    adapter.Commit();
    adapter.StartTransaction(IsolationLevel.ReadCommitted, "MultiEntityInsertion");
    PizzasListEntity pizzaRow = new PizzasListEntity();
    pizzaRow.Topping = receivedOrder.Pizza.Topping;
    pizzaRow.Size = receivedOrder.Pizza.Size;
    pizzaRow.OrderId = orderId;
    pizzaRow.Side = receivedOrder.Pizza.Side;
    pizzaRow.PricePerPizza = receivedOrder.Pizza.PricePerPizza;
    await adapter.SaveEntityAsync(pizzaRow, true);
    adapter.Commit();
    return new OkObjectResult(receivedOrder);
});

await app.RunAsync();

static void LLBLGen()
{
    var connectionString = "Server=localhost;Database=pizza_app;Port=5432;User Id=postgres;Password=root;";
    NpgsqlConnection.GlobalTypeMapper.UseNetTopologySuite(geographyAsDefault: true);
    RuntimeConfiguration.AddConnectionString("ConnectionString.PostgreSql (Npgsql)", connectionString);
    RuntimeConfiguration.ConfigureDQE<PostgreSqlDQEConfiguration>(c =>
    {
        c.AddDbProviderFactory(typeof(NpgsqlFactory));
        c.SetTraceLevel(System.Diagnostics.TraceLevel.Verbose);
    });
}