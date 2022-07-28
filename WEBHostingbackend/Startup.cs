using System;
using WEBHostingbackend.Repository;
using Microsoft.AspNetCore.Builder;

using Microsoft.Extensions.Configuration;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using WEBHostingbackend.Infrastructure.IServices;
using WEBHostingbackend.Infrastructure.Services;
using WEBHostingbackend.Repository.IRepository;
using WEBHostingbackend.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WEBHostingbackend.Repository.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SpeakOut.Entities.Models;

namespace WEBHostingbackend
{
    public class Startup
    {

        readonly string MyAllowSpecificOrigins = "MyAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();





            services.AddCors(options =>
            {
                options.AddPolicy("MyAllowSpecificOrigins",
     builder =>
     {
         builder
         .WithOrigins("http://localhost:4200")
         .AllowAnyHeader()
         .AllowAnyMethod();
     });

            });

            services.AddControllersWithViews();
            services.AddTransient<IServeurServices, ServeurServices>();
            services.AddTransient<IServeurRepository, ServeursRepository>();

            //services.AddTransient<IUserServices, UserServices>();
            services.AddTransient<IUserRepository, UsersRepository>();


            services.AddSwaggerGen((options) =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Backend API", Version = "v1" });

            });

            services.AddTransient<IServiceServices, ServiceServices>();
            services.AddTransient<IServiceRepository, ServiceRepository>();

            services.AddTransient<IServeurServices, ServeurServices>();
            services.AddTransient<IServeurRepository, ServeursRepository>();
            services.AddTransient<IPayementServices, PayementServices>();
            services.AddTransient<IPayementRepository, PayementRepository>();
            services.AddTransient<IDomainServices, DomainServices>();
            services.AddTransient<IDomainRepository, DomainRepository>();
            services.AddTransient<IUserServices, UserServices>();
           services.AddTransient<IUserRepository, UsersRepository>();
            //services.AddDbContext<WebHostingDbContext>();
            services.AddDbContext<WebHostingDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
           // services.AddIdentity<User,UserRole>(opt => { }).AddEntityFrameworkStores<WebHostingDbContext>();
          //  services.AddIdentityCore<ApplicationUser>()
              //.AddEntityFrameworkStores<WebHostingDbContext>();
            services.AddIdentity<AspNetUsers, AspNetRoles>()
               .AddEntityFrameworkStores<WebHostingDbContext>()
               .AddDefaultTokenProviders();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
            }
            );
            //JWT Authentification
            var Key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero,


                };
            });

        }
        public void Configure(IHostingEnvironment env, IApplicationBuilder app)

        {
            app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();
            app.UseRouting();


            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });
            //specify the Swagger JSON endpoint
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Backend API");
                c.RoutePrefix = string.Empty;
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(

                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}")
                .RequireCors(MyAllowSpecificOrigins);
            });


        }
    }
}
