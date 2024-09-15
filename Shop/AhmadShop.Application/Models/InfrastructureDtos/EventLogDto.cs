using Microsoft.Extensions.Logging;


namespace AhmadShop.Application.Models.InfrastructureDtos;

public sealed class EventLogDto
{
    public DateTime DateTime { get; private set; } = DateTime.Now;
    public string? ServiceName { get; set; }
    public LogLevel logLevel { get; set; }
    public string? UserId { get; set; }
    public int Line { get; set; }
    public string? Description { get; set; }
    public required string Source { get; set; }
    public object? Data { get; set; }
    public string? Exception { get; set; }
}
