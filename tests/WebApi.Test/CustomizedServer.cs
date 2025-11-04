using CashFlow.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Test;
public class CustomizedServer : WebApplicationFactory<Program> // Aqui define um servidor de teste de integração usando WebApplicationFactory (Nosso servidor do .NET)
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Test")
            .ConfigureServices(services => {
                var provider = services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

                services.AddDbContext<CashFlowDbContext>(options => {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                    options.UseApplicationServiceProvider(provider);
                });
            }); 
    }
}
