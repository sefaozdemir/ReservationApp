using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReservationApp.Core.Interface;
using ReservationApp.Core.Repository;

namespace ReservationApp.UnitTest
{
    class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
        .SetBasePath(System.IO.Directory.GetCurrentDirectory())
        .Build();

            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<ITableRepository, TableRepository>();

        }
    }
}
