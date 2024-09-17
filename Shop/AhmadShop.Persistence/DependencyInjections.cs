using AhmadShop.Application.ExternalInterfaces.DbConteracts;
using AhmadShop.Domain.Entities.Users;
using AhmadShop.Persistence.Manager;
using CHMS.Persistence.EF.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Persistance.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmadShop.Persistence
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AhmadShopContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<AhmadShopContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<ICHMSDbContext, AhmadShopContext>();
            services.AddScoped<IUserRepository, UserRepository>();



            services.AddScoped<AppUserManager>();
            services.AddScoped<AppSignInManager>();
            services.AddScoped<AppRoleManager>();


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme =
                      JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme =
                      JwtBearerDefaults.AuthenticationScheme;
            })
       .AddJwtBearer(options =>
       {
           options.RequireHttpsMetadata = false;
           options.SaveToken = true;
           options.ClaimsIssuer = configuration["Authentication:JwtIssuer"];

           options.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuer = true,
               ValidIssuer = configuration["Authentication:JwtIssuer"],

               ValidateAudience = true,
               ValidAudience = configuration["Authentication:JwtAudience"],

               ValidateIssuerSigningKey = true,
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:JwtKey"])),
               RequireExpirationTime = true,
               ValidateLifetime = true,
               ClockSkew = TimeSpan.Zero
           };
       });


            services.Configure<DataProtectionTokenProviderOptions>(opt => opt.TokenLifespan = TimeSpan.FromHours(3));

            return services;
        }


    }
}
