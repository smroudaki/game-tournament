using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameTournament.Api.Services;
using GameTournament.Application;
using GameTournament.Application.Common.Interfaces;
using GameTournament.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GameTournament.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure(Configuration);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyMethod()
                           .AllowAnyHeader()
                           .WithOrigins("http://localhost:3000")
                           .WithOrigins("http://127.0.0.1:3000")
                           .WithOrigins("http://localhost:3001")
                           .WithOrigins("http://127.0.0.1:3001")
                           .WithOrigins("http://GameTournament.com")
                           .WithOrigins("http://admin.GameTournament.com")
                           .AllowCredentials();
                });
            });

            //services.AddCors(options =>
            //{
            //    options.AddDefaultPolicy(builder =>
            //    {
            //        builder.SetIsOriginAllowed(origin => true)
            //               .AllowAnyMethod()
            //               .AllowAnyHeader()
            //               .AllowCredentials();
            //    });
            //});

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddControllers()
                .AddJsonOptions(x => x.JsonSerializerOptions.IgnoreNullValues = true);

            services.AddSwaggerDocumentation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerDocumentation();

            app.UseStaticFiles();
            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
