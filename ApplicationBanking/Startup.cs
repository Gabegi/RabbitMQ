using RabbitMQBankingApplication.AutoMapper;
using RabbitMQBankingApplication.Handler;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace RabbitMQBankingApplication
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {

            builder.Services.AddAutoMapper(typeof(MappingProfile));
            // builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(MoneyTransferHandler).Assembly));


        }
    }
}
