using MediatR;

namespace AhmadShop.Application.Behaviors;

[AttributeUsage(AttributeTargets.Class)]
public class CacheableAttribute(int duration = 60) : Attribute
{
    public int Duration => duration;
}

public class CachingBehavior<TRequest, TResponse>(ICacheService cacheService) :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ICacheService cacheService = cacheService;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {

        // Get from cache
        try
        {
            var cacheableAttribute = (CacheableAttribute?)Attribute.GetCustomAttribute(request.GetType(), typeof(CacheableAttribute));
            if (cacheableAttribute is null)
                return await next();


            var cacheKey = typeof(TRequest).Name;
            var response = await cacheService.GetAsync<TResponse>(cacheKey, cancellationToken);
            if (response is not null)
                return response;

            response = await next();
            await cacheService.SetAsync(cacheKey, response, TimeSpan.FromSeconds(cacheableAttribute.Duration), cancellationToken);
            return response;
        }
        catch (Exception)
        {

            throw;
        }

    }
}