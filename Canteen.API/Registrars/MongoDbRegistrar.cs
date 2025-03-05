using Canteen.DataAccessLayer.Data;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Canteen.API.Registrars
{
    public class MongoDbRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            // Bind MongoDB settings from configuration
            builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

            // Register MongoDbConfig as a Singleton
            builder.Services.AddSingleton<MongoDbConfig>();

            // Register MongoDbContext as a Singleton
            builder.Services.AddSingleton<MongoDbContext>();

            // Register MongoClient
            builder.Services.AddSingleton<IMongoClient>(sp =>
            {
                var settings = sp.GetRequiredService<MongoDbConfig>();
                return new MongoClient(settings.Database.Client.Settings);
            });

            // Register MongoDatabase
            builder.Services.AddSingleton(sp =>
                sp.GetRequiredService<IMongoClient>().GetDatabase(
                    builder.Configuration.GetSection("MongoDbSettings:DatabaseName").Value));
        }
    }
}
