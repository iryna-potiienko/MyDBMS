using DBMSServices.Mappers;
using DBMSServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DBMSServices
{
    public static class ServiceDependencies
    {
        public static void AddService(this IServiceCollection services, IConfiguration configuration)
        {
            // services.AddNewtonsoftJson(options =>
            //         options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            //     );
            
            services.AddScoped<DatabaseService>();
            services.AddScoped<TableService>();
            services.AddScoped<AttributeService>();
            services.AddScoped<RowService>();
            services.AddScoped<CellService>();
            
            services.AddScoped<TablesDifferenceService>();
            services.AddScoped<ValidateService>();
            services.AddScoped<ReadSaveDatabaseInFileService>();
        }

        public static void AddMapper(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<DatabaseMapper>();
            services.AddScoped<AttributeMapper>();
        }
    }
}