using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TopInternsBoardingPassSorter.Application.Logic;
using TopInternsBoardingPassSorter.Domain.Models.TopInternsTransportationCards;
using TopInternsBoardingPassSorter.Services;
using TopInternsBoardingPassSorter.Services.TopInternsBusService;
using Microsoft.OpenApi.Models;
using System;

namespace TopInternsBoardingPassSorter
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
            services.AddControllers();
            services.AddTransient<ITopInternsBusService, TopInternsBusService>();
            services.AddTransient<ITopInternsTransCardsSorter<TopInternsTransportationCard>, TopInternsTransCardsSorter>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TopInterns API",
                    Version = "v1",
                    Description = "Sorting transportation cards algorithm.",
                    Contact = new OpenApiContact
                    {
                        Name = "Tariq Senosy",
                        Email = "tariqsenosy@gmail.com"
                    },
                });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TopInterns API V1");

                // To serve SwaggerUI at application's root page, set the RoutePrefix property to an empty string.
                c.RoutePrefix = string.Empty;
            });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

   
}
