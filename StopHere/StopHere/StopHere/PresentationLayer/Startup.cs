using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer;
using System.Reflection;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace PresentationLayer
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
            services.AddAuthentication("CookieAuthentication")
            .AddCookie("CookieAuthentication", config =>
            {
                config.Cookie.Name = "UserLoginCookie";
                config.LoginPath = "/User/Login";
                config.AccessDeniedPath = "/User/PermissionDenied";
            });

            services.AddControllersWithViews();
            services.AddSignalR();
            //services.AddTransient<ILegalPersonService, LegalPersonBLL>();
            //services.AddTransient<INaturalPersonService, NaturalPersonBLL>();
            services.AddTransient<IUserService, UserBLL>();
            services.AddTransient<IVehicleService, VehicleBLL>();
            services.AddTransient<IMaps, MapsBLL>();
            services.AddTransient<IParkingService, ParkingBLL>();
            services.AddTransient<ILocationService, LocationBLL>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddHttpContextAccessor();
            services.AddMvc();
            services.AddSession();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(new CultureInfo("pt-br")),
                SupportedCultures = new List<CultureInfo>()
                {
                    new CultureInfo("pt-br")
                }
            });


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
