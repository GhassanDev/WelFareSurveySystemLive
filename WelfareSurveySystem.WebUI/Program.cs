using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WelfareSurveySystem.Data;
using WelfareSurveySystem.Domain.Business;
using WelfareSurveySystem.Domain.DataRepositories;
using WelfareSurveySystem.WebUI.Data;

namespace WelfareSurveySystem.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // IoC Configuration - Dependancy Injection
            builder.Services.AddScoped<IWelfareSurveySystemBusiness, WelfareSurveySystemBusiness>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<ITaskRequestRepository, TaskRequestRepository>();
            builder.Services.AddScoped<IDeceasedRepository, DeceasedRepository>();


            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");



            //builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
            //.AddEntityFrameworkStores<ApplicationDbContext>();
            //.AddRoles<IdentityRole>();





            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDbContext<WelfareSurveySystemDBContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddRoles<IdentityRole>()
            .AddDefaultUI();



            builder.Services.AddDatabaseDeveloperPageExceptionFilter();



            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}