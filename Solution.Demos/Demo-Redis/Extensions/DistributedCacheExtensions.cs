using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace Demo_Redis.Extensions
{
    public static class DistributedCacheExtensions
    {
        public static async Task SetRecordAsync<T>(this IDistributedCache cache,
        string recordId, // Key : 캐쉬된 항목의 고유 식별자로 사용됨 즉, 이것이 반복될 수 없다는 의미
        T data, // 저장될 데이터, 모델의 배열 즉, 객체의 배열
        TimeSpan? absoluteExpireTime = null,
        TimeSpan? unusedExpireTime = null)
        {

        }
    }
}
