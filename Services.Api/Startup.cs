using DataLayer.Dados.Contracts;
using DataLayer.Dados.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Api
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
            var connection = Configuration.GetConnectionString("DbConn");

            services.AddTransient<IPacienteRepository, PacienteRepository>(map => new PacienteRepository(connection));
            services.AddTransient<IConvenioRepository, ConvenioRepository>(map => new ConvenioRepository(connection));


            services.AddSwaggerGen(
                 swg =>
                 {
                     swg.SwaggerDoc("v1", new OpenApiInfo
                     {
                         Title = "Be3 - Gestão de Pacientes",
                         Version = "v1",
                         Description = "API de Gestão de Pacientes do grupo be3"
                     });
                 });

            //services.AddCors();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                    builder.SetIsOriginAllowed(_ => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
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

            app.UseAuthorization();
            app.UseCors(x => x
                 .AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader()
                 .SetIsOriginAllowed(origin => true));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(
                swgUi =>
                {
                    swgUi.SwaggerEndpoint("/swagger/v1/swagger.json", "be3");
                }
            );
        }
    }
}
