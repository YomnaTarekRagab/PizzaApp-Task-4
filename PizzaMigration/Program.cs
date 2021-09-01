using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using PizzaMigration.Migrations;

namespace PizzaMigration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter your command:");
            var option = Console.ReadLine();
            if (option != null)
            { 
                var commandStringArr = option.Split(" ");
                var upOrDown = commandStringArr[0];
                var serviceProvider = CreateServices();
                using (var scope = serviceProvider.CreateScope())
                {
                    if (upOrDown.Equals("--up"))
                    {
                        Console.WriteLine("Updating the database");
                        UpdateDatabase(scope.ServiceProvider);
                    }

                    else if (upOrDown.Equals("--down"))
                    {
                        Console.WriteLine("Rollbacking the database");
                        var downVersion = Convert.ToInt32(commandStringArr[1]);
                        if (downVersion > -1)
                            RollbackDatabase(scope.ServiceProvider, downVersion);
                    }
                }
            }
        }

        private static IServiceProvider CreateServices()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            var configString = configuration["ConnectionString"];
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddPostgres()
                    .WithGlobalConnectionString(configString)
                    .ScanIn(typeof(_001_PizzaToppings).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }

        private static void RollbackDatabase(IServiceProvider serviceProvider, long rollbackVersion)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateDown(rollbackVersion);
        }
    }
}
