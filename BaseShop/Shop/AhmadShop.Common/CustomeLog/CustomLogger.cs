using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmadShop.Common.CustomeLog;

public static class CustomLogger
{
    public static void CustomeLogInformation(this ILogger logger, string Message, int Line, string Service, string ServiceName, string? ExceptionMessage = null)
    {
        logger.LogInformation($"CreatedAt: {DateTime.Now}, ExceptionMessage: {ExceptionMessage}, Message: {Message}, Line: {Line}, Service: {Service}, ServiceName: {ServiceName}");
    }

    public static void CustomeLogWarning(this ILogger logger, string Message, int Line, string Service, string ServiceName, string? ExceptionMessage = null)
    {
        logger.LogWarning($"CreatedAt: {DateTime.Now}, ExceptionMessage: {ExceptionMessage}, Message: {Message}, Line: {Line}, Service: {Service}, ServiceName: {ServiceName}");
    }

    public static void CustomeLogError(this ILogger logger, string Message, int Line, string Service, string ServiceName, string? ExceptionMessage = null)
    {
        logger.LogError($"Message: {Message}, Line: {Line}, Service: {Service}, ServiceName: {ServiceName},ExceptionMessage: {ExceptionMessage}");
    }
}
