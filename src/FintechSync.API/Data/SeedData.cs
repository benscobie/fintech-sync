using FintechSync.API.Identity;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FintechSync.API.Data
{
    public class SeedData
    {
        public static void EnsureSeedData(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<FintechSyncContext>(options =>
            options.UseNpgsql(connectionString, o => o.MigrationsAssembly(typeof(Program).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<FintechSyncContext>()
                .AddDefaultTokenProviders();

            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<FintechSyncContext>();
                    context.Database.Migrate();

                    var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    var ben = userMgr.FindByNameAsync("ben").Result;
                    if (ben == null)
                    {
                        ben = new ApplicationUser
                        {
                            UserName = "ben",
                            Email = "admin@benscobie.com",
                            EmailConfirmed = true,
                        };
                        var result = userMgr.CreateAsync(ben, "L@l123").Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        result = userMgr.AddClaimsAsync(ben, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "Ben Scobie"),
                        }).Result;

                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }
                    }
                }
            }
        }
    }
}
