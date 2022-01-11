using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RentReady.Sample.Business.Abstract;
using RentReady.Sample.Business.Concrete;
using RentReady.Sample.DataAccess.Abstract;
using RentReady.Sample.DataAccess.Concrete.EntityFramework;
using RentReady.Sample.MvcWebUI.Entities;
using RentReady.Sample.MvcWebUI.Middlewares;
using RentReady.Sample.MvcWebUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentReady.Sample.MvcWebUI
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
            //**Added Scopes
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<ICardService, CardService>();

            //**Only One Created (For Session)
            services.AddSingleton<ICardSessionService, CardSessionService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //**Session Service (Hold in Memory)
            services.AddSession();
            services.AddDistributedMemoryCache();

            //services.AddControllersWithViews();
            services.AddDbContext<CustomIdentityDbContext>
           (option => option.UseSqlServer(Configuration.GetConnectionString("AuthDBConnection")));

            //services.AddDbContext<AuthDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("AuthDBConnection")));

            services.AddIdentity<CustomIdentityUser, CustomIdentityRole>()
                .AddEntityFrameworkStores<CustomIdentityDbContext>()
                .AddDefaultTokenProviders();


            services.AddMvc(option => option.EnableEndpointRouting = false);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            //app.UseRouting();
            //app.UseAuthorization();

            app.UseFileServer();
            app.UseNodeModules(env.ContentRootPath);
            app.UseSession();
            app.UseMvcWithDefaultRoute();
            app.UseMvc(ConfigureRoutes);
        }



        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            //Home/Index
            routeBuilder.MapRoute("Default", "{controller=Product}/{action=Index}/{id?}");
        }
    }
}
