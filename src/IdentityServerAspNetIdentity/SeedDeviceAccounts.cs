

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using IdentityModel;
using IdentityServerAspNetIdentity.Data;
using IdentityServerAspNetIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace IdentityServerAspNetIdentity
{
    public class SeedDeviceAccounts
    {
        public static void EnsureSeedData(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddLogging();

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<ApplicationDbContext>(options =>
               options.UseNpgsql(connectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<ApplicationDbContext>();                   

                    var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                    List<ApplicationUser> devicelist = new List<ApplicationUser>()
                    {
                        new ApplicationUser
                            {
                                UserName = "device1",
                                Email = "device1@vehiclesystems.com",
                                EmailConfirmed = true,
                            },
                         new ApplicationUser
                            {
                                 UserName = "device2",
                                Email = "device2@vehiclesystems.com",
                                EmailConfirmed = true,
                            },
                         new ApplicationUser
                            {
                                UserName = "device3",
                                Email = "device3@vehiclesystems.com",
                                EmailConfirmed = true,
                            }
                         ,
                         new ApplicationUser
                            {
                                UserName = "device4",
                                Email = "device4@vehiclesystems.com",
                                EmailConfirmed = true,
                            }
                         ,
                         new ApplicationUser
                            {
                                UserName = "device5",
                                Email = "device5@vehiclesystems.com",
                                EmailConfirmed = true,
                            }
                    };
                   
                    foreach(var device in devicelist)
                    {
                        var exist=userMgr.FindByNameAsync(device.UserName).Result;
                        if(exist==null)
                        {
                            var result = userMgr.CreateAsync(device, "Pass123$").Result;
                            if (!result.Succeeded)
                            {
                                Log.Debug(result.Errors.First().Description);
                            }
                        }
                    }
                   
                }
            }
        }
    }
}
