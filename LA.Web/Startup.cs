using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LA.Web
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
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthorization();
            app.UsePathBase("/locationapplication/");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Use(async (context, next) =>
            {
                // TODO Check if host is valid based on hosts in ForwardedHeadersOptions
                if (context.Request.Headers.TryGetValue("X-Path-Base", out var pathBase) &&
                    context.Request.Path.StartsWithSegments(pathBase.Last(), out var matchedPath, out var remainingPath))
                {
                    try
                    {
                        var originalPath = context.Request.Path;
                        var originalPathBase = context.Request.PathBase;
                        context.Request.PathBase = matchedPath;
                        context.Request.Path = remainingPath;
                        await next();
                    }
                    finally
                    {
                        context.Request.PathBase = new PathString(matchedPath);
                        context.Request.Path = new PathString(remainingPath);
                    }
                }
                else
                {
                    await next();
                }
            });
        }
    }
}
