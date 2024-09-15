using AhmadShop.Common.CustomeLog;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace AhmadShop.Infrastructure.ExternalServices;

public sealed class SerilogService : ISerilogService
{
    //private bool _disposed;

    public void CustomLog(LogLevel logLevel, string source, string serviceName, [CallerLineNumber] int line = 0, string? userId = "", string? description = "", object? data = null, string? exception = "")
    {
        var options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true
        };
        EventLogDto eventLog = new EventLogDto
        {
            Source = source,
            UserId = userId,
            ServiceName = serviceName,
            logLevel = logLevel,
            Line = line,
            Data = JsonSerializer.Serialize(data, options),
            Description = description,
            Exception = exception
        };
        Info(eventLog);
    }

    private static void Info(EventLogDto infoToLog)
    {

        Log.Information(
            "{DateTime} {ServiceName} {logLevel}" +
            "{UserId} {Line} {Description}" +
            "{Source} {Data} {Exception}"
            , infoToLog.DateTime, infoToLog.ServiceName, infoToLog.logLevel
            , infoToLog.UserId, infoToLog.Line, infoToLog.Description
            , infoToLog.Source, infoToLog.Data, infoToLog.Exception);

    }
}
