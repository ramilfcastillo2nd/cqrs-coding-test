using Microsoft.AspNetCore.Mvc;
using outdesk.codingtest.api.Errors;
using outdesk.codingtest.Infrastructure.Data;
using outdesk.codingtest.Infrastructure.Data.Repositories;
using outdesk.codingtest.Infrastructure.Data.Repositories.Interfaces;
using outdesk.codingtest.Infrastructure.Services;
using outdesk.codingtest.Infrastructure.Services.Interfaces;

namespace outdesk.codingtest.api.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IBookService, BookService>();

            //Repositories
            //services.AddScoped<IJobRepository, JobRepository>();
            //services.AddScoped<IEmployerRepository, EmployerRepository>();
            //services.AddScoped<IDriverRouteRepository, DriverRouteRepository>();
            //services.AddScoped<ITransportationRepository, TransportationRepository>();
            //services.AddScoped<IDriverRepository, DriverRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });

            return services;
        }
    }
}
