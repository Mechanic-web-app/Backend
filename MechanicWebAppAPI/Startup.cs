using MechanicWebAppAPI.Common.Helpers;
using MechanicWebAppAPI.Core.Helpers;
using MechanicWebAppAPI.Core.Interfaces;
using MechanicWebAppAPI.Core.Repositories;
using MechanicWebAppAPI.Core.Dtos;
using MechanicWebAppAPI.Data.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using NSwag;
using NSwag.Generation.Processors.Security;
using System.Text;
using MechanicWebAppAPI.Api.Responses.Factories;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace MechanicWebAppAPI
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
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAutoMapper(typeof(AutoMapping));
            services.AddHttpContextAccessor();
            services.AddScoped<ICars, CarRepository>();
            services.AddScoped<IOpinions, OpinionRepository>();
            services.AddScoped<IUsers, UserRepository>();
            services.AddScoped<IRepairs, RepairRepository>();
            services.AddScoped<IAuthentication, AuthenticationRepository>();
            services.AddScoped<IJwtHelper, JwtHelper>();
            services.AddScoped<IApiResponseFactory, ApiResponseFactory>();
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AppDbContext")));
            services.AddControllers();

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
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddSwaggerDocument(document =>
            {
                document.DocumentName = "swagger";
                document.Title = "MechanicWebApp - API";
                document.Version = "0.1.0";
                document.OperationProcessors.Add(new OperationSecurityScopeProcessor("jwt"));
                document.DocumentProcessors.Add(new SecurityDefinitionAppender("jwt", new NSwag.OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "JWT Token - remember to add 'Bearer ' before the token",
                }));
                document.GenerateEnumMappingDescription = true;
            });
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:8080").AllowAnyMethod().AllowAnyHeader(); ;
                    });
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseOpenApi(options =>
            {
                options.DocumentName = "swagger";
                options.Path = "/swagger/v1/swagger.json";
                options.PostProcess = (document, _) => document.Schemes.Add(NSwag.OpenApiSchema.Https);
            });

            app.UseSwaggerUi3(options => options.DocumentPath = "/swagger/v1/swagger.json");

            app.UseCors();
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            DatabaseSeeder.SeedData(context);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
