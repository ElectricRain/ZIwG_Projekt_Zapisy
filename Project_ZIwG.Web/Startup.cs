using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Project_ZIwG.Domain.Auth;
using Project_ZIwG.Domain.Auth.Interfaces;
using Project_ZIwG.Domain.Auth.Models;
using Project_ZIwG.Domain.UserGetter;
using Project_ZIwG.Infrastructure.Repositories.EFRepository;
using Project_ZIwG.Infrastructure.Repositories.EFRepository.Context;
using Project_ZIwG.Infrastructure.Repositories.Interfaces;
using System.Text;

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

            services.Configure<AuthSecrets>(Configuration.GetSection(nameof(AuthSecrets)));

            services.AddAuthentication("JWT_Auth")
                .AddJwtBearer("JWT_Auth", config =>
                {
                    var secretBytes = Encoding.UTF8.GetBytes(Configuration.GetValue<string>("AuthSecrets:Key"));
                    var key = new SymmetricSecurityKey(secretBytes);

                    config.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = Configuration.GetValue<string>("AuthSecrets:Issuer"),
                        ValidAudience = Configuration.GetValue<string>("AuthSecrets:Audience"),
                        IssuerSigningKey = key
                    };
                });


            services.AddScoped<DbContext, UserContext>();
            services.AddScoped<IUserRepository, EFUserRepository>();
            services.AddScoped<ICourseRepository, EFCourseRepository>();
            services.AddScoped<IRolesRepository, EFRolesRepository>();
            services.AddScoped<ISubjectRepository, EFSubjectRepository>();
            services.AddScoped<ITypeRepository, EFTypeRepository>();
            services.AddScoped<IUserPermissionRepository, EFUserPermissionRepository>();
            services.AddScoped<IUserRolesRepository, EFUserRolesRepository>();


            services.AddScoped<IAuthenticator, Authenticator>();
            services.AddScoped<UserGetter>();

            services.AddSwaggerGen();
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

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
