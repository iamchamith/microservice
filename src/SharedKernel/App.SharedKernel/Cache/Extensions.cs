using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using App.SharedKernel.Extension;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;

namespace RedisRepo
{
    public static class Extensions
    {
        public static HashEntry[] ToHashEntity<T>(this List<T> items) where T : Entity<int>
        {
            var hashList = new List<HashEntry>();
            if (items != null)
            {
                items.ForEach(item =>
                {
                    hashList.Add(new HashEntry(item.Id, item.ToJsonString<T>()));
                });
            }
            return hashList.ToArray();
        }

        public static List<T> ToObjectList<T>(this HashEntry[] items)
        {
            var result = new List<T>();
            if (items != null)
            {
                items.ToList().ForEach(item =>
                {
                    result.Add(item.Value.ToString().ToObject<T>());
                });
            }
            return result;
        }
    }
}
