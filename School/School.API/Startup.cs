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
using School.API.BusinessLogic.Implementations;
using School.API.BusinessLogic.Interfaces;
using School.API.Entities;
using School.API.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.API
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
            var connectionDb = Configuration.GetConnectionString("SchoolDb");
            services.AddDbContext<SchoolContext>(options => options.UseSqlServer(connectionDb));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "School.API V1", Version = "v1" });
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "School.API V2", Version = "v2" });

                var fileComment = System.IO.Path.Combine(System.AppContext.BaseDirectory, "School.Api.xml");
                if (System.IO.File.Exists(fileComment))
                    c.IncludeXmlComments(fileComment);
            });

            services.AddTransient<IClassRoomBL, ClassRoomBL>();
            services.AddTransient<ICourseBL, CourseBL>();
            services.AddTransient<IStudentBL, StudentBL>();

            services.AddTransient<IClassRoomRepository, ClassRoomRepository>();
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI( c =>
                  {
                      c.SwaggerEndpoint("/swagger/v1/swagger.json", "School.API v1");
                      c.SwaggerEndpoint("/swagger/v2/swagger.json", "School.API v2");
                  }
                );      
            }

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
