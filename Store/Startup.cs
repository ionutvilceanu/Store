﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalaJocuriLicenta.Data;
using SalaJocuriLicenta.Models;
using SalaJocuriLicenta.Services;
using Microsoft.AspNetCore.Mvc;
using SalaJocuriLicenta.Repository;
using Microsoft.AspNetCore.Http;


namespace SalaJocuriLicenta
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





            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddTransient<IProductRepository, ProductRepository>();
            

            //!!!!!!!
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            services.AddScoped(sp => SCart.GetCart(sp));


            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = "355559355080658";
                facebookOptions.AppSecret = "3bd9c94f862d450eab88334418976f5f";
            });
            services.AddAuthentication()
            .AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = "1091943113711-38llh09h3n0uq39mgf0fl8n83tsebosa.apps.googleusercontent.com";
                googleOptions.ClientSecret = "kfTHt7MQBQ-u_UHj_PLE9jIo";




            });

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
            services.AddSession();
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

           
            app.UseStaticFiles();


            app.UseAuthentication();

            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
