using MongoDB.Driver;
using WrestlingMvcFinal.Models;

namespace WrestlingMvcFinal
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            builder.Services.AddSingleton<IMongoClient>(new MongoClient("mongodb://localhost:27017"));
            builder.Services.AddSingleton<IMongoDatabase>(sp =>
                sp.GetRequiredService<IMongoClient>().GetDatabase("WrestlingFinal"));
            builder.Services.AddSingleton<IMongoCollection<Match>>(sp =>
                sp.GetRequiredService<IMongoDatabase>().GetCollection<Match>("ProWrestling"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();
            app.MapGet("/", () => Results.Redirect("/Shared/Index"));

            app.Run();
        }
    }
}
