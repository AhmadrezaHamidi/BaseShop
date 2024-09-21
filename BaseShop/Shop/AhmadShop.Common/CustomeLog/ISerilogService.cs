using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace AhmadShop.Common.CustomeLog;

public interface ISerilogService
{
    void CustomLog(LogLevel logLevel, string source, string serviceName, [CallerLineNumber] int line = 0, string? userId = "", string? description = "", object? data = null, string? exception = "");
}
