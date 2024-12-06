

using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Memory;

namespace DotnetFeatures;
/// <summary>
/// 与IDistributedCache ：每次都要处理很多工作，包括序列化之类的操作。 
/// 在缓存缺失的情况下，最终可能会有多个并发线程，对于这些线程而言，
/// 其均会经历如下过程：出现缓存缺失，获取基础数据，对数据执行序列化，然后将数据发送至缓存
/// 
/// 
/// </summary>
public class HybridCacheExample
{
    public static async Task BUild()
    {
        // 1. 配置服务
        var services = new ServiceCollection();

        // 添加 HybridCache
        services.AddHybridCache(options =>
        {
            options.DefaultEntryOptions = new HybridCacheEntryOptions
            {
                Expiration = TimeSpan.FromMinutes(30)
            };
        });

        // 添加 Redis（可选）
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = "localhost:6379";
        });

        var serviceProvider = services.BuildServiceProvider();

        // 2. 获取缓存实例
        var cache = serviceProvider.GetRequiredService<HybridCache>();

        var userModel = new User
        {
            Id = 1,
            Name = "张三"
        };
        var user = await GetSomeInfoAsync(cache, userModel.Name, userModel.Id);

        Console.WriteLine($"用户名: {user}");

        await cache.RemoveAsync("user:1");
    }
    public static async Task<string> GetSomeInfoAsync(HybridCache _cache, string name, int id, CancellationToken token = default)
    {
        return await _cache.GetOrCreateAsync(
            $"{name}-{id}", // Unique key to the cache entry
            async cancel => await GetDataFromTheSourceAsync(name, id, cancel),
            cancellationToken: token
        );
    }

    public static async Task<string> GetDataFromTheSourceAsync(string name, int id, CancellationToken token)
    {
        string someInfo = $"someinfo-{name}-{id}";
        return someInfo;
    }
}
public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
