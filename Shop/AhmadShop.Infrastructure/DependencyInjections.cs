using AhmadShop.Application.ExternalInterfaces.Caching;
using AhmadShop.Application.ExternalInterfaces.Serilog;
using AhmadShop.Infrastructure.ExternalServices;
using AhmadShop.Infrastructure.ServicesConfig;
using Asp.Versioning;
using CHMS.Infrastructure.Caching;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmadShop.Infrastructure;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastruture(this IServiceCollection services, IConfiguration configuration)
    {
        SerilogConfigs.UseSqlServer(configuration);


        return services;
    }

    private static void AddCaching(IServiceCollection services)
    {
        services.AddSingleton<ICacheService, CacheService>();
    }

    private static void AddApiVersioning(IServiceCollection services)
    {
        services
            .AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1);
                options.ReportApiVersions = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            })
            .AddMvc()
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'V";
                options.SubstituteApiVersionInUrl = true;
            });
    }


}



