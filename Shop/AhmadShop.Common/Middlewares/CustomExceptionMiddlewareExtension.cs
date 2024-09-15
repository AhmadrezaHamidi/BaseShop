using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AhmadShop.Common.CustomeLog;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using AhmadShop.Common.CustomModels;
using AhmadShop.Common.Extensions;
using ValidationException = FluentValidation.ValidationException;
using static AhmadShop.Common.Extensions.DateExtension;

namespace AhmadShop.Common.Middlewares;

public static class CustomExceptionMiddlewareExtension
{
    public static void UseCustomExceptionMiddleware(IApplicationBuilder app)
    {
        var logger = app.ApplicationServices.GetRequiredService<ISerilogService>();
        app.UseExceptionHandler(c => c.Run(async context =>
        {
            context.Response.StatusCode = 400;
            var exception = context.Features
                .Get<IExceptionHandlerPathFeature>()
                ?.Error;

            ErrorResponse error;

            if (exception is AppException appException)
            {
                error = new ErrorResponse
                {
                    Code = (int)appException.Code,
                    Type = appException.Code.GetDisplayName(),
                    //Message = string.IsNullOrWhiteSpace(appException.MessageParams)
                    //   ? string.Format(appException.Code.GetDescription(), appException.MessageParams)
                    //   : appException.CustomMessage,
                    Message = string.IsNullOrEmpty(appException.CustomMessage) ? appException.CustomMessage :
                        string.Format(appException.Code.GetDescription(), appException.MessageParams),
                    AdditionalData = appException.AdditionalData
                };
            }
            else if (exception is { Source: "FluentValidation" })
            {
                var validationException = (ValidationException)exception;
                var exceptionCode = ExceptionCode.ValidationException;
                error = new ErrorResponse()
                {
                    Code = (int)exceptionCode,
                    Type = exceptionCode.GetDisplayName(),
                    Message = validationException.Message,
                    AdditionalData = validationException.Errors.Select(x => new { Value = x.AttemptedValue, Message = x.ErrorMessage }).ToList()
                };
            }
            else
            {
                var exceptionCode = ExceptionCode.SystemException;
                error = new ErrorResponse()
                {
                    Code = (int)exceptionCode,
                    Message = exceptionCode.GetDescription(),
                    Type = exceptionCode.GetDisplayName()
                };
            }
            await context.Response.WriteAsJsonAsync(error);
            logger.CustomLog(logLevel: LogLevel.Error, source: "AppException", serviceName: error.Type, description: $"Message: {error.Message} ** AdditionalData: {error.AdditionalData}");
        }));
    }

    public static string JoinParamsWithComma(object[] parameters)
    {
        if (parameters.Count() == 0)
            return null;

        var stringParams = parameters.Select(p => p.ToString()).ToArray();
        return string.Join(", ", stringParams);
    }

    private class ErrorResponse
    {
        public string Type { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public object? AdditionalData { get; set; }
    }
}
