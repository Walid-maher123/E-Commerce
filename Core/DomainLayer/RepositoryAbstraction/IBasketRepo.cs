using DomainLayer.Entities.BasketModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.RepositoryAbstraction
{
   
    public  interface IBasketRepo
    {

          

        Task<CustomerBasket?> GetBasketAsync(string Key);

        Task<bool> DeleteBasketAsync(string Key);

        Task<CustomerBasket> CreateOrUpdateAsync(CustomerBasket basket,TimeSpan? timeSpan=null);
    }
}
