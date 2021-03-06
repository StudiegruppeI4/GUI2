using System;
using System.Collections.Generic; 
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Morgenmadsbuffeten.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Morgenmadsbuffeten.Models;
using System.Security.Claims;

namespace Morgenmadsbuffeten
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
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MorgenmadsbuffetenContextConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews(); 
            services.AddRazorPages();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("IsWaiter", policy => policy.RequireClaim("Waiter"));
                options.AddPolicy("IsReceptionist", policy => policy.RequireClaim("Receptionist"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider,
            RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] roles = { "Waiter", "Receptionist" };
            foreach (string role in roles)
            {
                if (!roleManager.RoleExistsAsync(role).Result)
                    roleManager.CreateAsync(new IdentityRole(role)).Wait();
            }
        }

        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            string[] emails = {"Waiter@Localhost", "Reception@Localhost", "Chef@Chef"};
            string[] passwords = { "Secret7$", "Secret8$", "Secret9$"};
            Claim[] claims = { new Claim("Waiter", "Yes"), new Claim("Receptionist", "Yes")};

            for (int i = 0; i < emails.Length; i++)
            {
                if (userManager.FindByNameAsync(emails[i]).Result == null)
                {
                    var user = new IdentityUser();
                    user.Email = emails[i];
                    user.UserName = emails[i];
                    user.EmailConfirmed = true;
                    IdentityResult result = userManager.CreateAsync(user, passwords[i]).Result;
                    if (result.Succeeded)
                    {
                        if (i <= 1)
                        {
                            userManager.AddClaimAsync(user, claims[i]).Wait();
                        }
                    }
                }
            }
        }
    }
}