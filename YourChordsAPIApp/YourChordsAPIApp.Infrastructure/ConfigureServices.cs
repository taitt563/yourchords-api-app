using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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

            //services.AddTransient<IUserRoleRepository, UserRoleRepository>();
            services.AddTransient<IChordTypeRepository, ChordTypeRepository>();
            services.AddTransient<IArtistRepository, ArtistRepository>();
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<IArtistGenreRepository, ArtistGenreRepository>();
            services.AddTransient<IUserAccountRepository, UserAccountRepository>();
            services.AddTransient<ICollectionRepository, CollectionRepository>();
            services.AddTransient<IInstrumentRepository, InstrumentRepository>();

            services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings.GetValue<string>("SecretKey");
            //var validAudience = jwtSettings.GetValue<string>("ValidAudience");
            //var validIssuer = jwtSettings.GetValue<string>("ValidIssuer");

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme; // this is for SignalR
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    //ValidIssuer = validIssuer,
                    //ValidAudience = validAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Customer", policy => policy.RequireRole("Admin"));
                options.AddPolicy("Musician", policy => policy.RequireRole("Musician"));
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
                options.AddPolicy("ChordValidator", policy => policy.RequireRole("ChordValidator"));
            });

            services.AddHttpContextAccessor();

            return services;
        }
    }
}
