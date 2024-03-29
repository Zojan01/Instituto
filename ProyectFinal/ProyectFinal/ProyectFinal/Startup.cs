﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Persistence;
using Service;
using Swashbuckle.AspNetCore.Swagger;

namespace ProyectFinal
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
            var connection = @"Server=(localdb)\mssqllocaldb;Database=Db;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<ProjectDbContext>(options => options.UseSqlServer(connection));



           
            services.AddTransient<ICursosService, CursosService>();
            services.AddTransient<IProfesoresService, ProfesoresService>();
            services.AddTransient<IEstudiantesService, EstudiantesService>();
            services.AddTransient<IParientesService, ParientesService>();
            services.AddTransient<IEstudianteParienteService, EstudianteParienteService>();


            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info { Title = "Employee API", Version = "V1" });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "post API V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
