using AhmadShop.Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace AhmadShop.Application
{
    public static IServiceCollection AddApplicationDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMemoryCache();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));

        services.AddTransient<IValidator<ConfirmChequeCommand>, ConfirmChequeCommandValidator>();

        services.AddScoped(sp => new UserInfo());
        services.AddScoped(sp => new BranchInfo());

        //services.AddScoped<UserInfoFactory>();

        return services;
    }
}
