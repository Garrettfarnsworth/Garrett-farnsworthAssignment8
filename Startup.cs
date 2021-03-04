using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineBooks.Models;

namespace OnlineBookStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        //This method is called by the runtime and can be used to add services
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //The connection string that connects to our database and sql server. Pro tip, don't add any spaces into the quotations.
            services.AddDbContext<OnlineBookStoreDbContext>(options =>
           {
               options.UseSqlServer(Configuration["ConnectionStrings:BooksConnection"]); 

           });

            services.AddScoped<IBookRespository, EFBookRespository>();
        }

        //This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                //The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            { //This code is for the pagination that we are doing and this controls the dynamic output of pages based on the database and how many pages are needed.
                endpoints.MapControllerRoute("catpage",
                    "{category}/{page:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("page",
                    "{page:int}",
                    new { Controller = "Home", action = "Index", page = 1});

                endpoints.MapControllerRoute("category",
                    "{category}",
                    new { Controller = "Home", action = "Index", page = 1 });

                endpoints.MapControllerRoute(
                    "pagination",
                    "P/{page}",
                    new { Controller = "Home", action = "Index", page = 1});

            endpoints.MapDefaultControllerRoute();
            });

            //Makes sure that the datbase gets populated
            SeedData.EnsurePopulated(app);
        }
    }
}
