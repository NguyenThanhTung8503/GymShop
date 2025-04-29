using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.Data.EF
{
    public class ShopGYMDbContextFactory : IDesignTimeDbContextFactory<ShopGYMDbContext>
    {
        public ShopGYMDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("GYMShopDatabase");

            var optionsBuilder = new DbContextOptionsBuilder<ShopGYMDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ShopGYMDbContext(optionsBuilder.Options);
        }
    }

}
