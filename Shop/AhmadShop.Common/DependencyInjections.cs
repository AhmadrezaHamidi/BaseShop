using AhmadShop.Common.CustomeLog;
using AhmadShop.Infrastructure.ExternalServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmadShop.Common
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddCommonInjections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ISerilogService, SerilogService>();
            var seqServerUrl = configuration["Seq:localSeqServer"];

            Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .WriteTo.Seq(seqServerUrl)
                    .CreateLogger();



            return services;
        }
    }
}
