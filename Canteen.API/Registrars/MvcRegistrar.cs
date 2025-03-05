using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Canteen.API.Filters;

namespace Canteen.API.Registrars
{
    public class MvcRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers(config =>
            {
                //The filter will be available globally
                config.Filters.Add(typeof(ApiExceptionHandler));
            });



            builder.Services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;                                                                                                                      
                config.ApiVersionReader = new UrlSegmentApiVersionReader();
            }

            );

            builder.Services.AddVersionedApiExplorer(config =>
            {
                config.GroupNameFormat = "'v'VVV";
                config.SubstituteApiVersionInUrl = true;
            });

            builder.Services.AddEndpointsApiExplorer();


            // Use MongoDbRegistrar to register MongoDB services
            var mongoRegistrar = new MongoDbRegistrar();
            mongoRegistrar.RegisterServices(builder);  // This calls the MongoDbRegistrar's RegisterServices method
        }
    }
}
