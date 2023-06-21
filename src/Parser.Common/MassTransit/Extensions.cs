using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Parser.Common.Settings;
using System.Reflection;

namespace Parser.Common.MassTransit
{
    public static class Extensions
    {
        public static IServiceCollection AddMassTransitWithRabbitMQ(this IServiceCollection services)
        {
        services.AddMassTransit(config =>
            {
                config.AddConsumers(Assembly.GetEntryAssembly());
                config.UsingRabbitMq((context, configurator) =>
       {
                     var configuration = context.GetService<IConfiguration>() ?? throw new InvalidOperationException("Configuration Not Found");
                     ServiceSettings serviceSettings = configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>() ?? throw new InvalidOperationException("Section  'ServiceSettings' not found.");
                     RabbitMQSettings rabbitMQSettings = configuration.GetSection(nameof(RabbitMQSettings)).Get<RabbitMQSettings>() ?? throw new InvalidOperationException("Section  'RabbitMQSettings' not found.");
                     configurator.Host(rabbitMQSettings.Host);
                     configurator.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter(serviceSettings.ServiceName, false));
                 });
            });
            //services.AddMassTransitHostedService();
            return services;
        }
    }
}
