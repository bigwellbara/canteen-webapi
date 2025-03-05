
using Canteen.Application.Queries.UserProfileQueries;
using MediatR;

namespace Canteen.API.Registrars
{

    //Jimmy Bogard, is the creator of AutoMapper and has worked on mediatr 
    // You can name it AutoMapperMediatRRegistrar or BogardRegistrar
    public class AutoMapperMediatRRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            // Add AutoMapper
            builder.Services.AddAutoMapper(typeof(Program), typeof(GetAllUserProfiles));
            // Add MediatR (without ServiceFactory)
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllUserProfiles).Assembly));
        }
    }

}
