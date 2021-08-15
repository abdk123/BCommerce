using Bwr.Core.Domain.Configuration;
using Bwr.Services.Caching;

namespace Bwr.Services.Configuration.Caching
{
    /// <summary>
    /// Represents a setting cache event consumer
    /// </summary>
    public partial class SettingCacheEventConsumer : CacheEventConsumer<Setting>
    {
    }
}