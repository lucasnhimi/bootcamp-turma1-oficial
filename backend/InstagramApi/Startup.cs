using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using InstagramApi.Context;
using InstagramApi.Repositories;
using InstagramApi.Services;
using InstagramApi.Utils;
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

namespace InstagramApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // add cors
            services.AddCors();

            // add swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Instagram API", Version = "v1" });
            });

            // add entity framework
            services.AddEntityFrameworkNpgsql()
                  .AddDbContext<InstagramContext>(options =>
                  {
                      options.UseNpgsql("Server=Localhost;Port=5432;Database=instagram;User Id=postgres;Password=password;",
                      b =>
                      {
                          b.MigrationsAssembly("InstagramApi");
                      });
                  });

            // add dependency injection
            var builder = new ContainerBuilder();

            builder.Populate(services);
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();

            builder.RegisterAssemblyTypes(typeof(Repository<>).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRepository<>));        
                
            var container = builder.Build();

            return new AutofacServiceProvider(container);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // add cors
            app.UseCors(option => option.AllowAnyOrigin()
                                  .AllowAnyMethod()
                                  .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // add swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API V1");
            });
        }
    }
}
