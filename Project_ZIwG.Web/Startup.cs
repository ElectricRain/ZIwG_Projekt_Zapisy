using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project_ZIwG.Domain.Auth;
using Project_ZIwG.Domain.Auth.Interfaces;
using Project_ZIwG.Infrastructure.Interfaces;
using Project_ZIwG.Infrastructure.Repositories.EFRepository;
using Project_ZIwG.Infrastructure.Repositories.EFRepository.Context;
using Project_ZIwG.Infrastructure.Repositories.InMemoryRepository;

namespace Project_ZIwG.Web
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
            services.AddDbContext<UserContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"),
                                                          o => o.MigrationsAssembly("Project_ZIwG.Infrastructure")));
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.AccessDeniedPath = "/denied";
                options.LoginPath = "/login";
            });

            services.AddScoped<IUserRepository, EFUserRepository>();

            services.AddScoped<IAuthenticator, Authenticator>();
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
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
