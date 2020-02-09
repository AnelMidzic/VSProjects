using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FirstMvcApp
{
    public class Startup
    { 
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration["ConnectionString"];
        }

        public static String ConnectionString;
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddLocalization(opts => opts.ResourcesPath = "Resources");


            services.AddMvc().AddDataAnnotationsLocalization(opts => {
                opts.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(typeof(Resource));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            services.Configure<RequestLocalizationOptions>(
                opts =>
                {
                    var supported = new[]
                    {
                        new CultureInfo("en"),
                        new CultureInfo("sr"),
                        new CultureInfo("de-DE")
                    };
                    opts.DefaultRequestCulture = new RequestCulture(culture:"en",uiCulture:"en-US");
                    opts.SupportedCultures = supported;
                    opts.SupportedUICultures = supported;
                }    
            );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

            app.UseAuthentication();

            app.UseRequestLocalization();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                routes.MapRoute(
                    name: "details",
                    template: "attendant/{firstName}-{lastName}",
                    defaults: new {
                        controller = "Home",
                        action = "AttendantDetails"
                    },
                    constraints: new { firstName = "[a-z]{3,7}" }
                );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseCookiePolicy();
        }
    }
}
