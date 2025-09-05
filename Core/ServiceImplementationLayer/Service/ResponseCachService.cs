using ServiceAbstractionLayer.IServices;
using SharedDataLayer.OrderDTOs;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServiceImplementationLayer.Service
{
    public class ResponseCachService : IResponseCachService
    {
        private readonly IDatabase _database;
        public ResponseCachService(IConnectionMultiplexer connection)
        {
             _database=connection.GetDatabase();
        }
        public async Task CachData(string Key, object Response, TimeSpan timeSpan)
        {
            if (Response == null) return;

            var option = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy= JsonNamingPolicy.CamelCase
                };
            var jsonData =  JsonSerializer.Serialize(Response, option);

             await _database.StringSetAsync(Key,jsonData,timeSpan);


        }

        public async Task<string?> GetCachedData(string Key)
        {
           var GetData= await _database.StringGetAsync(Key);
            if (string.IsNullOrEmpty(GetData))
                return null;
            return GetData;
        }
    }
}
