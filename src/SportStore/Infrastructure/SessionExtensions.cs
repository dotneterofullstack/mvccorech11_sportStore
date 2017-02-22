 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Infrastructure
{
    public static class SessionExtensions
    {
        public static void SetJson(this ISession sessiom, string key, object value)
        {
            sessiom.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetJson<T>(this ISession sessiom, string key)
        {
            var sessionData = sessiom.GetString(key);

            return sessionData == null ?
                default(T) : JsonConvert.DeserializeObject<T>(sessionData);
        }
    }
}
