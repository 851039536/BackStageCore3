using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BackStageCore3.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Storage;

namespace BackStageCore3
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


            services.AddCors(options =>
            {
                options.AddPolicy("any", builder =>
                {
                    //builder.AllowAnyOrigin() //允许任何来源的主机访问
                    builder

                        .WithOrigins("http://*.*.*.*")//.SetIsOriginAllowedToAllowWildcardSubdomains()//设置允许访问的域

                        .AllowAnyMethod()

                        .AllowAnyHeader()

                        .AllowCredentials();//

                });

            });

            services.AddControllers();
            
            //注册swagger
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1.0", new OpenApiInfo { Title = "1", Version = "1.0" });
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    c.IncludeXmlComments(xmlPath);
                });
            // other service configurations go here
            // replace "YourDbContext" with the class name of your DbContext
            services.AddDbContextPool<DbModel>(options => options
                // replace with your connection string
                .UseMySql("Server=localhost;Database=test;User=root;Password=woshishui;", mySqlOptions => mySqlOptions
                    // replace with your Server Version and Type
                    .ServerVersion(new ServerVersion(new Version(8, 0, 19), ServerType.MySql))
                ));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<CorsMiddleware>();//跨域

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            //Swagger规范和Swagger UI
            app.UseSwagger();
            app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "1");
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
