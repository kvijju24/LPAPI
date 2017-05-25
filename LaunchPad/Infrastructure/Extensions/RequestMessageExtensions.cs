using LaunchPad.Data.Repositories;
//using LaunchPad.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Dependencies;
using System.Web.Script.Serialization;

namespace LaunchPad.Infrastructure.Extensions
{
    public static class RequestMessageExtensions
    {
        //internal static ISecurityService GetSecurityService(this HttpRequestMessage request)
        //{
        //    return request.GetService<ISecurityService>();
        //}

        internal static IEntityBaseRepository<T> GetDataRepository<T>(this HttpRequestMessage request) where T : class, new()
        {
            return request.GetService<IEntityBaseRepository<T>>();
        }

        private static TService GetService<TService>(this HttpRequestMessage request)
        {
            IDependencyScope dependencyScope = request.GetDependencyScope();
            TService service = (TService)dependencyScope.GetService(typeof(TService));

            return service;
        }
        public static Dictionary<string, string> GetQueryStrings(this HttpRequestMessage request)
        {
            return request.GetQueryNameValuePairs().ToDictionary(kv => kv.Key, kv => kv.Value,StringComparer.OrdinalIgnoreCase);
        }
        public static T DeserializeObject<T>(this HttpRequestMessage request, string key) where T : class
        {
            var queryValues = request.GetQueryNameValuePairs().ToDictionary(kv => kv.Key, kv => kv.Value, StringComparer.OrdinalIgnoreCase);            var value = queryValues[key];
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            return javaScriptSerializer.Deserialize<T>(value);
        }
    }
}