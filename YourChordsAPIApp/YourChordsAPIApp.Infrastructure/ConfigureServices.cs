using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Entities;
using YourChordsAPIApp.Domain.Repositories;
using YourChordsAPIApp.Infrastructure.Repositories;

namespace YourChordsAPIApp.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<YourChordsDbContext>(options =>
            {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), builder => builder.MigrationsAssembly(typeof(YourChordsDbContext).Assembly.FullName));
            });

            services.AddTransient<IUserRoleRepository, UserRoleRepository>();
            services.AddTransient<IChordTypeRepository, ChordTypeRepository>();
            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IArtistGenreRepository, ArtistGenreRepository>();
            return services;
        }
    }
}
