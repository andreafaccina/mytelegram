﻿using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.DependencyInjection;
using MyTelegram.Core;

namespace MyTelegram.Caching.Redis;

public static class MyTelegramCachingExtensions
{
    public static IServiceCollection AddMyTelegramStackExchangeRedisCache(this IServiceCollection services,
        Action<RedisCacheOptions>? options = null)
    {
        services.AddTransient<ICacheSerializer, CacheSerializer>();
        services.AddSingleton(typeof(ICacheManager<>), typeof(CacheManager<>));
        services.AddStackExchangeRedisCache(redisOptions => { options?.Invoke(redisOptions); });
        return services;
    }
}
