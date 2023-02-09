using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using PHShippingApp.Domain.Interfaces.Repositories;
using PHShippingApp.Infra.Persistence.Repositories;

namespace PHShippingApp.Infra
{
    public static class InfraModule
    {
        public static IServiceCollection AddInfra(this IServiceCollection services)
        {
            services
                .AddMongo()
                .AddRepositories();

            return services;
        }

        public static IServiceCollection AddMongo(this IServiceCollection services)
        {
            services.AddSingleton<MongoDbOptions>(sp =>
            {
                var config = sp.GetService<IConfiguration>();
                var options = new MongoDbOptions();

                config.GetSection("Mongo").Bind(options);

                return options;
            });

            services.AddSingleton<IMongoClient>(sp =>
            {
                var options = sp.GetService<MongoDbOptions>();

                var mongoClient = new MongoClient(options.ConnectionString);
                var db = mongoClient.GetDatabase(options.DatabaseName);

                var dbseed = new DbSeed(db);
                dbseed.Populate();

                return mongoClient;
            });

            services.AddTransient<IMongoDatabase>(sp =>
            {
                var options = sp.GetService<MongoDbOptions>();
                var mongoClient = sp.GetService<IMongoClient>();

                var db = mongoClient.GetDatabase(options.DatabaseName);

                return db;
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IShippingOrderRepository, ShippingOrderRepository>();
            services.AddScoped<IShippingServiceRepository, ShippingServiceRepository>();
            return services;
        }
    }
}
