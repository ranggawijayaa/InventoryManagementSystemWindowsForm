using InventoryManagementSystem.Domain;
using InventoryManagementSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagementSystem.WinForms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile($"appsettings.{environment}.json", optional: false, reloadOnChange: true)
                .Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, config);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Ensure database is created
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = serviceProvider.GetRequiredService<MainForm>();
            Application.Run(mainForm);
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(config.GetConnectionString("DefaultConnection")));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddTransient<MainForm>();
            services.AddTransient<AddProductForm>();
            services.AddTransient<UpdateProductForm>();
        }
    }
}