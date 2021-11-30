using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EarthNear1.Interfaces;
using EarthNear1.Services.ShiftServices;
using EarthNear1.Services.UserServices;
using EarthNear1.Services;
using EarthNear1.Services.BookingServices;
using EarthNear1.Services.ShiftTypeServices;
using EarthNear1.Services.ShiftUserServices;

namespace EarthNear1
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
            services.AddRazorPages();
            services.AddSingleton<LogInService>();
            services.AddTransient<IShiftService, ShiftService>();
            services.AddTransient<ADO_ShiftService>();
            services.AddTransient<IShiftTypeService, ShiftTypeService>();
            services.AddTransient<ADO_ShiftTypeService>();
            services.AddTransient<IShiftUserService, ShiftUserService>();
            services.AddTransient<ADO_ShiftUserService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ADO_UserService>();
            services.AddTransient<IBookingService, BookingService>();
            services.AddTransient<ADO_BookingService>();
            services.AddTransient<IShiftTypeService, ShiftTypeService>();
            services.AddTransient<ADO_ShiftTypeService>();
            services.AddTransient<IShiftUserService, ShiftUserService>();
            services.AddTransient<ADO_ShiftUserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
