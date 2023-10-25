using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Repositories;
using YourChordsAPIApp.Infrastructure.Data;
using YourChordsAPIApp.Infrastructure.Repositories;

namespace YourChordsAPIApp.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<yourchordsdbContext>(options =>
            {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), builder => builder.MigrationsAssembly(typeof(yourchordsdbContext).Assembly.FullName));
            });

            services.AddTransient<IRolesRepository, RoleRepository>();
            return services;
        }
    }
}
