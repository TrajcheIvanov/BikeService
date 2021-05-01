using BikeService.Email;
using BikeService.Models;
using BikeService.Repositories;
using BikeService.Repositories.Interfaces;
using BikeService.Services;
using BikeService.Services.interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService
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
            services.AddDbContext<BikeServiceDbContext>(
                x=> x.UseSqlServer(Configuration.GetConnectionString("BikeService"))
                );
            
            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<BikeServiceDbContext>()
                    .AddDefaultTokenProviders();

            services.AddSingleton<IEmailSender, EmailSender>();
            services.Configure<EmailOptions>(Configuration);

            services.AddAuthentication().AddFacebook(fb =>
            {

                fb.AppId = "165031325536870";
                fb.AppSecret = "66f34978e52d3b62a65c21f4eba4f108";

            });


            services.AddRazorPages();

            //register repositories
            services.AddTransient<IServiceTypesRepository, ServiceTypesRepository>();
            services.AddTransient<IBikesRepository, BikesRepository>();

            //register services
            services.AddTransient<IServiceTypesService, ServiceTypesService>();
            services.AddTransient<IBikesService, BikesService>();
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

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
