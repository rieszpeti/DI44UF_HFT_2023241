using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using DI44UF_HFT_2023241.Logic;
using DI44UF_HFT_2023241.Models;
using DI44UF_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DI44UF_HFT_2023241.Repository.ModelRepositories;

namespace DI44UF_HFT_2023241.Endpoint
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
            services.AddTransient<OrderDbContext>();

            services.AddTransient<IRepository<Movie>, MovieRepository>();
            services.AddTransient<IRepository<Role>, RoleRepository>();
            services.AddTransient<IRepository<Actor>, ActorRepository>();
            services.AddTransient<IRepository<Director>, DirectorRepository>();

            services.AddTransient<IMovieLogic, MovieLogic>();
            services.AddTransient<IRoleLogic, RoleLogic>();
            services.AddTransient<IActorLogic, ActorLogic>();
            services.AddTransient<IDirectorLogic, DirectorLogic>();

            //Repositories
            services.AddTransient<IRepositorySpecial<IAddress>, AddressRepository>();
            services.AddTransient<IRepositorySpecial<ICustomer>, CustomerRepository>();
            services.AddTransient<IRepository<IOrder>, OrderRepository>();
            services.AddTransient<IRepository<IOrderDetail>, OrderDetailRepository>();
            services.AddTransient<IRepositorySpecial<IProduct>, ProductRepository>();

            //Business Logic
            services.AddTransient<ILogicSpecial<IAddress>, AddressLogic>();
            services.AddTransient<ILogicSpecial<ICustomer>, CustomerLogic>();
            services.AddTransient<ILogic<IOrder>, OrderLogic>();
            services.AddTransient<ILogic<IOrderDetail>, OrderDetailLogic>();
            services.AddTransient<ILogicSpecial<IProduct>, ProductLogic>();

            //services.AddControllers();

            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DI44UF_HFT_2023241.Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DI44UF_HFT_2023241.Endpoint v1"));
            }

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                var response = new { Msg = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
