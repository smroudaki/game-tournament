using GameTournament.Application.Common.Interfaces;
using GameTournament.Infrastructure.Helpers;
using GameTournament.Infrastructure.Persistence;
using GameTournament.Infrastructure.Repositories;
using GameTournament.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure strongly typed settings objects
            string jwtSecret = configuration.GetValue<string>("JWT:Secret").ToString();
            string kavenegarApiKey = configuration.GetValue<string>("KavenegarApiKey").ToString();
            var emailConfiguration = configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();

            // Configure dbcontext
            services.AddDbContext<GameTournamentTournamentContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Server"),
                    b => b.MigrationsAssembly(typeof(GameTournamentTournamentContext).Assembly.FullName)));

            // Configure JWT authentication
            var secret = Encoding.ASCII.GetBytes(jwtSecret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secret),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            // Configure DI for application services
            services.AddSingleton(emailConfiguration);
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<ISmsService>(provider => new SmsService(kavenegarApiKey));
            services.AddScoped<IZarinPalService, ZarinPalService>();

            return services;
        }
    }
}
