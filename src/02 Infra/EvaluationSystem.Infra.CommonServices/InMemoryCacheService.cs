using EvaluationSystem.Core.Domain.Common.Enums;
using EvaluationSystem.Core.Domain.Common.Services;
using EvaluationSystem.Utilities.Helpers;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Infra.CommonServices
{
    public class InMemoryCacheService : ICacheProviderService
    {
        private readonly IDistributedCache distributedCache;

        public InMemoryCacheService(IDistributedCache  distributedCache)
        {
            this.distributedCache = distributedCache;
        }

        public void Delete(CacheNameSpace nameSpace, string key)
        {
            if (nameSpace != CacheNameSpace.None)
                key = nameSpace.ToDisplay() + key;
            try { distributedCache.Remove(key); }
            catch { }
        }

        public T Get<T>(CacheNameSpace nameSpace, string key)
        {
            if (nameSpace != CacheNameSpace.None)
                key = nameSpace.ToDisplay() + key;
            var value = distributedCache.GetString(key);
            try
            {
                return SerializerHelper.DeSerialize<T>(value);
            }
            catch
            {
                return default(T);
            }           
        }

        public void Set<T>(CacheNameSpace nameSpace, string key, T value)
        {
            if (nameSpace != CacheNameSpace.None)
                key = nameSpace.ToDisplay() + key;
            distributedCache.SetString(key,SerializerHelper.SerializeObject(value));           
        }
    }
}
