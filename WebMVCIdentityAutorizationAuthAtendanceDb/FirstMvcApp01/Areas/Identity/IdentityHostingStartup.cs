using System;
using FirstMvcApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(FirstMvcApp.Areas.Identity.IdentityHostingStartup))]
namespace FirstMvcApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<FirstMvcAppContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("FirstMvcAppContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<FirstMvcAppContext>();
            });
        }
    }
}