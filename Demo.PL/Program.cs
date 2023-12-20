using Demo.Bll.Interfaces;
using Demo.Bll.Repository;
using Demo.Dal.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Demo.Bll.Repository;
using Demo.Bll.Interfaces;
using Demo.Bll;
using Demo.PL.ViewModels;
using Demo.Dal.Models;
using Demo.PL.profiles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Demo.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container. 
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<Mydbcontext>(
                Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("Conf")));
            builder.Services.AddScoped<IUniteOfWork, UniteOfWork>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            //builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<Mydbcontext>()
               .AddDefaultTokenProviders();

            builder.Services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
                Options =>
                {
                    Options.LoginPath = "Account/Login";
                    Options.AccessDeniedPath = "Account/Error";
                });
           
            builder.Services.AddAutoMapper(m => m.AddProfile(new EmployeeProfile()));
            builder.Services.AddAutoMapper(d => d.AddProfile(new DepartmentProfile()));

            var app = builder.Build();

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
            app.UseAuthorization();
          

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}