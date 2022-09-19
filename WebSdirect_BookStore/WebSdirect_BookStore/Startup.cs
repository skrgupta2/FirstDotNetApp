using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSdirect_BookStore
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
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        { 
        //    app.Use(async (context, next) =>
        //    {
        //        await context.Response.WriteAsync("Helo from my first middleware");
        //        await next();
        //        await context.Response.WriteAsync("Helo from my first middleware response");
        //    });
        //    app.Use(async (context, next) =>
        //    {
        //        await context.Response.WriteAsync("Helo from my second middleware");
        //        await next();
        //        await context.Response.WriteAsync("Helo from my second middleware response");
        //    });
        //    app.Use(async (context, next) =>
        //    {
        //        await context.Response.WriteAsync("Helo from my third middleware");
        //        await next();
        //        await context.Response.WriteAsync("Helo from my third middleware response");
        //    });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               // await env.EnvironmentName;
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
