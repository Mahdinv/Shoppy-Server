using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IResponseCacheService
    {
        Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeToLive); /*tozihat safe 19 mored 11*/
        Task<string> getCachedResponseAsync(string cacheKey);
    }
}
