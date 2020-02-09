using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebMvcModel03.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace WebMvcModel03
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<OsobaContext>(opcije =>
            opcije.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
            app.UseCookiePolicy();

            CultureInfo ci = new CultureInfo("sr-Latn-RS");
            ci.DateTimeFormat.DateSeparator = ".";
            ci.DateTimeFormat.ShortDatePattern = "d.M.yyyy";
            ci.NumberFormat.NumberDecimalSeparator = ".";

            List<CultureInfo> podrzaneKulture = new List<CultureInfo>
            {
                ci
            };
            RequestLocalizationOptions opcije = new RequestLocalizationOptions
            {
                SupportedCultures = podrzaneKulture,
                DefaultRequestCulture = new RequestCulture(ci)
            };

            app.UseRequestLocalization(opcije);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
