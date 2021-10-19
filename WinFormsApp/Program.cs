
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    static class Program
    {
//         private static void InitServices(IServiceCollection services)
//         {
//             services.AddScoped<DatabaseService>();
//             services.AddScoped<TableService>();
//             services.AddScoped<AttributeService>();
//             services.AddScoped<RowService>();
//             services.AddScoped<CellService>();
//             services.AddScoped<TablesDifferenceService>();
//         }
//
//         private static void InitRepositories(IServiceCollection services)
//         {
//             services.AddScoped<DatabaseRepository>();
//             services.AddScoped<TableRepository>();
//             services.AddScoped<AttributeRepository>();
//             services.AddScoped<RowRepository>();
//             services.AddScoped<CellRepository>();
//         }
//         private static void InitMappers(IServiceCollection services)
//         {
//             services.AddScoped<DatabaseMapper>();
//             services.AddScoped<AttributeMapper>();
//         }
//
//         //public static IConfiguration Configuration { get; }
//         private static void ConfigureServices(ServiceCollection services)
//         {
//             /*services.AddLogging(configure => configure.AddConsole())
//                     .AddScoped<IBusinessLayer, CBusinessLayer>()
//                     .AddScoped<IBusinessLayer, CBusinessLayer>()
//                     .AddSingleton<IDataAccessLayer, CDataAccessLayer>();
//
//             services.AddDbContext<MyDBMSContext>();
//
//             services.AddRepository(Configuration);
//             services.AddService(Configuration);
//             services.AddMapper(Configuration);
//             */
//
//             services.AddDbContext<MyDBMSContext>();
//
//             InitRepositories(services);
//             InitServices(services);
//             InitMappers(services);
//             services.AddScoped<Form1>();
//         }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // var services = new ServiceCollection();

            // services.AddDbContext<MyDBMSContext>();
            // services.AddScoped<Form1>();


            // using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            // {
            //     var form1 = serviceProvider.GetRequiredService<Form1>();
            //     Application.Run(form1);
            // }
            
            // var form1 = serviceProvider.GetRequiredService<Form1>();
            Application.Run(new Form1());
        }
    }
}
