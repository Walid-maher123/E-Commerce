using DomainLayer.Entities.BasketModels;
using DomainLayer.RepositoryAbstraction;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Presistance.RepositoryImplementation
{
    public class BasketRepo(IConnectionMultiplexer connection) : IBasketRepo
    {
        private readonly IDatabase _database=connection.GetDatabase();

        public async Task<bool> DeleteBasketAsync(string Key)
          => await _database.KeyDeleteAsync(Key);

        

        public async Task<CustomerBasket?> GetBasketAsync(string Key)
        {
          var databasket=  await _database.StringGetAsync(Key);
            if (databasket.IsNullOrEmpty)
                return null;
            else return JsonSerializer.Deserialize<CustomerBasket>(databasket!);
        }
        
        

        public async Task<CustomerBasket> CreateOrUpdateAsync(CustomerBasket basket,TimeSpan? timeSpan=null)
        {
            var jsonbasket = JsonSerializer.Serialize<CustomerBasket>(basket);
         var IsCreatedOrUpdate=  await _database.StringSetAsync(basket.Id, jsonbasket, TimeSpan.FromDays(30));
            if (IsCreatedOrUpdate == true)
                return await GetBasketAsync(basket.Id);
            else
                return null;
        }
    }
}
