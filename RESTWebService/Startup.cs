using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBMSServices;
using DBMSServices.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MyDBMS;
using MyDBMS.Contexts;
using MyDBMS.Repositories;

namespace RESTWebService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyDBMSContext>();
            
            services.AddRepository(Configuration);
            services.AddService(Configuration);
            //InitRepositories(services);
            //InitServices(services);
            
            services.AddControllers();
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "RESTWebService", Version = "v1"});
            });
        }

        private static void InitServices(IServiceCollection services)
        {
            services.AddScoped<DatabaseService>();
            services.AddScoped<TableService>();
            services.AddScoped<AttributeService>();
            services.AddScoped<RowService>();
            services.AddScoped<CellService>();
            services.AddScoped<TablesDifferenceService>();
        }

        private static void InitRepositories(IServiceCollection services)
        {
            services.AddScoped<DatabaseRepository>();
            services.AddScoped<TableRepository>();
            services.AddScoped<AttributeRepository>();
            services.AddScoped<RowRepository>();
            services.AddScoped<CellRepository>();
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RESTWebService v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}