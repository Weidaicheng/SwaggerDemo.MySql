using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SwaggerDemo.MySql.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace SwaggerDemo.MySql
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
            services.AddMvc();

            services.AddDbContext<SwaggerDemoContext>(options => options.UseMySQL(Configuration.GetConnectionString("MySql")));

            //swagger doc gen
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info() { Title = "SwaggerDemo v1", Version = "v1" });
            });

            //api version
            //services.AddApiVersioning(options =>
            //{
            //    options.DefaultApiVersion = new ApiVersion(1, 0);
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            //swagger
            app.UseSwagger();
            //swagger ui
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "SwaggerDemo v1");
            });
        }
    }
}
