using AutoMapper;
using EvaluationSystem.Core.ApplicationServices.EvaluationForms;
using EvaluationSystem.Core.ApplicationServices.Reporting;
using EvaluationSystem.Core.ApplicationServices.UserEvaluationForms;
using EvaluationSystem.Core.ApplicationServices.Users;
using EvaluationSystem.Core.Domain.Common.Data;
using EvaluationSystem.Core.Domain.Common.Repositories;
using EvaluationSystem.Core.Domain.Common.Services;
using EvaluationSystem.Core.Domain.EvaluationForms.Repositories;
using EvaluationSystem.Core.Domain.EvaluationForms.Services;
using EvaluationSystem.Core.Domain.UserEvaluationForms.Repositories;
using EvaluationSystem.Core.Domain.UserEvaluationForms.Services;
using EvaluationSystem.Core.Domain.Users.Repositories;
using EvaluationSystem.Core.Domain.Users.Services;
using EvaluationSystem.EndPoints.PanelWebApi.InfraStructures.ActionFilters;
using EvaluationSystem.Infra.CommonServices;
using EvaluationSystem.Infra.DAL.SQL;
using EvaluationSystem.Infra.DAL.SQL.EvaluationForms.Repositories;
using EvaluationSystem.Infra.DAL.SQL.Reporting.Repositories;
using EvaluationSystem.Infra.DAL.SQL.UserEvaluationForms.Repositories;
using EvaluationSystem.Infra.DAL.SQL.Users.Repositories;
using EvaluationSystem.Infra.Resources;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationSystem.EndPoints.PanelWebApi.InfraStructures.Extentions
{
    public static class ServiceCollectionExtention
    {
        public static void RegisterDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<EvaluationSystemDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("Default"));
            });
            services.AddScoped<SqlConnection>(opt => new SqlConnection(configuration.GetConnectionString("Default")));
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, EvaluationSystemUnitOfWork>();
            services.AddScoped<IUserRepository, EfUserRepository>();
            services.AddScoped<IEvaluationFormRepository, EfEvaluationFormRepository>();
            services.AddScoped<IUserEvaluationFormRepository, EfUserEvaluationFormRepository>();
            services.AddScoped<IReportRepository, AdoReportRepository>();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<ITokenGenerateService, GuIdTokenService>();
            services.AddScoped<IUserLoginService, UserLoginService>();
            services.AddScoped<IUserLogoutService, UserLogoutService>();
            services.AddScoped<IUserQueryService, UserQueryService>();
            services.AddScoped<IUserValidationService, UserValidationService>();
            services.AddScoped<ICacheProviderService, InMemoryCacheService>();
            services.AddScoped<IEvaluationFormQueryService, EvaluationFormQueryService>();
            services.AddScoped<IUserEvaluationFormQueryService, UserEvaluationFormQueryService>();
            services.AddScoped<IUserEvaluationFormRegisterService, UserEvaluationFormRegisterService>();
            services.AddScoped<IReportingService, ReportingService>();

            services.AddScoped<CustomAuthorizeActionFilterAttribute>();
        }

        public static void RegisTerthirdParties(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

  
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EvaluationSystem.EndPoints.PanelWebApi", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please Insert Your Token Into Field",
                    Name = HttpItemsResource.AccessTokenKeyName,
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
   {
     new OpenApiSecurityScheme
     {
       Reference = new OpenApiReference
       {
         Type = ReferenceType.SecurityScheme,
         Id = "Bearer"
       }
      },
      new string[] { }
    }
  });
            });
        }
    }
}
