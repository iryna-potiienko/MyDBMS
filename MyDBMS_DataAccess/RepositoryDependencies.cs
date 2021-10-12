using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyDBMS.Repositories;

namespace MyDBMS
{
    public static class RepositoryDependencies
    {
        public static void AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<DatabaseRepository>();
            services.AddScoped<TableRepository>();
            services.AddScoped<AttributeRepository>();
            services.AddScoped<RowRepository>();
            services.AddScoped<CellRepository>();
        }
    }
}