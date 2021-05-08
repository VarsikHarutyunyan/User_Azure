using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Users.Services;
using Users.DataContexts;
[assembly: FunctionsStartup(typeof(Users.Startup))]
namespace Users
{
    public class Startup : FunctionsStartup
    {
        public string SqlServerConnection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=User;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
     
            public override void Configure(IFunctionsHostBuilder builder)
        {
            var connectionString = SqlServerConnection;
             //   Environment.GetEnvironmentVariable("dbConnectionString");
            builder.Services.AddDbContext<DataContext>(x =>
            {
                x.UseSqlServer(connectionString
                , options => options.EnableRetryOnFailure());
            });

            builder.Services.AddTransient<IService, Service>();

        }
    }
}
