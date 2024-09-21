using AhmadShop.Application.ExternalInterfaces.Serilog;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmadShop.Application.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ISerilogService _serilogService;
    private static readonly string Source = typeof(TRequest).Name;
    private static readonly string ServiceName = "LoggingBehavior";

    public LoggingBehavior(ISerilogService serilogService)
    {
        _serilogService = serilogService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        /// Log request handling start
        _serilogService.CustomLog(LogLevel.Debug, Source, ServiceName, 0, userId: null, description: $"Handling {typeof(TRequest).Name}");

        // Call the next delegate/middleware in the pipeline
        var response = await next();

        // Log request handling completion
        _serilogService.CustomLog(LogLevel.Debug, Source, ServiceName, 0, userId: null, description: $"Handled {typeof(TRequest).Name}");

        return response;
    }
}
