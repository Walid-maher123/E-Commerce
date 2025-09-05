using SharedDataLayer.BasketDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstractionLayer.IServices
{
    public interface IBasketService
    {
        Task<bool> DeleteBasketAsync(string basketId);

        Task<BasketDTO> GetBasketAsync (string basketId);

        Task<BasketDTO> CreateOrUpdateBasketAsync(BasketDTO basketDTO);

     } 
}
