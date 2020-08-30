using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Database.Sql.ERP
{
    class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ERPContext>
    {
        public ERPContext CreateDbContext(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json")
                .Build();
            var builder = new DbContextOptionsBuilder<ERPContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new ERPContext(builder.Options);
        }
    }

}
