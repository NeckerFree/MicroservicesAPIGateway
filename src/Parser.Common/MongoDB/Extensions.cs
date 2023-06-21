
using Parser.Common.Entities;
using Parser.Common.Settings;
using MongoDB.Driver;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Parser.Common.Repositories
{
    public static class Extensions
    {
        public static IServiceCollection AdMongo (this IServiceCollection services )
        {
          services.AddSingleton(serviceProvider =>
            {
                var configuration = serviceProvider.GetService<IConfiguration>() ?? throw new InvalidOperationException("Configuration Not Found");
                ServiceSettings serviceSettings = configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>() ?? throw new InvalidOperationException("Section  'ServiceSettings' not found.");
                MongoDBSettings mongoSettings = configuration.GetSection(nameof(MongoDBSettings)).Get<MongoDBSettings>() ?? throw new InvalidOperationException("Section  'MongoDBSettings' not found.");
                var mongoClient = new MongoClient(mongoSettings.ConnectionString);
                return mongoClient.GetDatabase(serviceSettings.ServiceName);
            });
            return services;
        }

        public static IServiceCollection AddMongoRepository<T>(this IServiceCollection services, string collectionName) where T : IEntity
        {
            services.AddSingleton<IRepository<T>>(serviceProvider =>
            {
                var database = serviceProvider.GetService<IMongoDatabase>();
                return new MongoRepository<T>(database ?? throw new InvalidOperationException("Mongo Database Not Found"), "clients");
            });
            return services;
        }
    }
}
