using EvaluationSystem.Core.Domain.Common.Enums;

namespace EvaluationSystem.Core.Domain.Common.Services
{
    public interface ICacheProviderService
    {
        void Set<T>(CacheNameSpace nameSpace, string key, T value);
        T Get<T>(CacheNameSpace nameSpace, string key);
        void Delete(CacheNameSpace nameSpace, string key);
    }
}
