using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AutoMapper;
using NilsOchMartin.Models;
using NilsOchMartin.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace NilsOchMartin
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            var connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CarDB;Integrated Security=True";

            services.AddDbContext<CarDBContext>(
                options => options.UseSqlServer(connString));

            services.AddMvc();

            Mapper.Initialize((Config) =>
            {
                Config.CreateMap<CarsCreateVM, Car>();
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseMvcWithDefaultRoute();
            
        }
    }
}
