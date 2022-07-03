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
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "SpeakOut API", Version = "v1" });

            });


            services.AddTransient<IServeurServices, ServeurServices>();
            services.AddTransient<IServeurRepository, ServeursRepository>();

           services.AddTransient<IUserServices, UserServices>();
           services.AddTransient<IUserRepository, UsersRepository>();
            //services.AddDbContext<WebHostingDbContext>();
            services.AddDbContext<WebHostingDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
           // services.AddIdentity<AppUser, IdentityRole>(opt => { }).AddEntityFrameworkStores<WebHostingDbContext>() ;
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
