using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDamageAssessment.ApplicationCore.Interfaces;
using CarDamageAssessment.ApplicationCore.Interfaces.Repositories;
using CarDamageAssessment.Infrastructure.Data;
using CarDamageAssessment.Infrastructure.Data.Repositories;
using CarDamageAssessment.Web.Api.MiddleWares;
using Framework.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;

namespace CarDamageAssessment.Web.Api
{
    public class Startup
    {

        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        protected void IocSetting(IServiceCollection services)
        {
            var mongoSetting = new MongoSetting();
            _configuration.Bind("MongoSetting", mongoSetting);


            services.AddDbContext<CarDamageAssessmentContext>(c =>
                c.UseSqlServer(_configuration.GetConnectionString("CarDamageAssessmentConnection")));


            services.AddScoped<ICorporateRepository, CorporateRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IApiLogService>(x => new ApiLogService(mongoSetting));

        }

        public void ConfigureServices(IServiceCollection services)
        {


           

            IocSetting(services);


            MvcSetting(services);

            AuthenticationSetting(services);

           



            //services.AddAuthorization(options =>
            //{
            //  options.AddPolicy("userRole", policy =>
            //  {
            //    policy.AddAuthenticationSchemes("Bearer");
            //    policy.RequireClaim(ClaimTypes.Role, "member");
            //  });
            //});

        }

        private void AuthenticationSetting(IServiceCollection services)
        {
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.Authority = "http://localhost:5000/";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "http://localhost:5000",
                        ValidateAudience = true,
                        ValidAudience = "http://localhost:5000/resources",
                        ValidateLifetime = true,

                    };
                });
        }

        private void MvcSetting(IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            }).AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver
                    = new DefaultContractResolver();
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {


            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseStaticFiles();

            app.UseExceptionHandler();

            app.UseLogRequestMidleware();

            app.UseAuthentication();


            app.UseUnitOfworkMiddleware();



            app.UseMvcWithDefaultRoute();


            app.UseMvc();





        }
    }
}
