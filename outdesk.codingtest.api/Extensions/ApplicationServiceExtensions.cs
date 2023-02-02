using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using outdesk.codingtest.api.Errors;
using outdesk.codingtest.api.Helpers;
using outdesk.codingtest.Infrastructure.Data;
using outdesk.codingtest.Infrastructure.Data.Repositories;
using outdesk.codingtest.Infrastructure.Data.Repositories.Interfaces;
using outdesk.codingtest.Infrastructure.Services;
using outdesk.codingtest.Infrastructure.Services.Interfaces;
using System.ComponentModel;

namespace outdesk.codingtest.api.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IReservedBookService, ReservedBookService>();

            //Repositories
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IReservedBookRepository, ReservedBookRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            services.AddScoped<IDatabaseInitializer, DatabaseInitializer>();
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
