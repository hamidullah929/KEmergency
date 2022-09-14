
using Kemergency.Bussiness;
using Kemergency.Data;
using Kemergency.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency
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
            services.AddDbContextPool<ApplicationDbContext>(options =>
                  options.UseSqlServer(




             Configuration.GetConnectionString("DefaultConnection")));
            services.AddAuthorization(options =>
            {
                options.AddPolicy("DeleteRolePolicy", policy => policy.RequireClaim("Delete Role"));
            });
            //To satisfy EditRolePolicy, the logged-in user must have Edit Role claim
            services.AddAuthorization(options =>
            {
                options.AddPolicy("editrolepolicy", policy => policy.RequireClaim("edit role"));
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("SuperAdminPolicy", policy => policy.RequireRole("Admin"));

                //If you want to include multiple roles in the policy simply separate them with a comma
                //  options.AddPolicy("SuperAdminPolicy", policy =>
                //  policy.RequireRole("Admin", "User", "Manager"));
            });
            services.AddIdentity<ApplicationUser,IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddAutoMapper(typeof(HospitalProfile));
            services.AddScoped<BookingServices>();
            services.AddScoped<HospitalServices>();
            services.AddScoped<RentalServices>();
            services.AddScoped<CustomerServices>();
            services.AddScoped<AmbulanceServices>();
            services.AddScoped<FireTrackServices>();
            services.AddScoped<FireTrackBookingServices>();
            services.AddScoped<FireTrackRentalService>();
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddMvc();
        

            services.AddControllersWithViews().AddNewtonsoftJson();
            services.AddRazorPages();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
            app.UseSession();

            app.UseAuthentication();
           app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

               
                    endpoints.MapControllerRoute(
                      name: "Customer",
                      pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
                    );
                endpoints.MapControllerRoute(
                     name: "FireTrackK",
                     pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
                   );
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                      name: "Hospital",
                      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );
                });
                endpoints.MapRazorPages();
            });
        }
    }
}
