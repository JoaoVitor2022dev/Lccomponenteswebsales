using LccomponentesWeb.Data;
using LccomponentesWeb.Models;
using LccomponentesWeb.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Globalization;

namespace LccomponentesWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Add services to the container.
            string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContextPool<LccomponentesWebContext>(options =>
                options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

            // injerção de depedenci apara os serviços   
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<CategoriesService>();

            // Configure localization
            var supportedCultures = new[]
             {
             new CultureInfo("en-US"),
             new CultureInfo("pt-BR")
             };

            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"), // Defina a cultura padrão
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };

            builder.Services.AddControllersWithViews()
                .AddViewLocalization(); // Adicione esta linha para habilitar a localização nas visualizações

            var app = builder.Build();

            app.UseRequestLocalization(localizationOptions);

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
