using AutoMapper;
using DomainLayer.Entities.BasketModels;
using DomainLayer.RepositoryAbstraction;
using ServiceAbstractionLayer.IServices;
using ServiceImplementationLayer.Exceptions;
using SharedDataLayer.BasketDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementationLayer.Service
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepo _basketRepo;
        private readonly IMapper _mapper;

        public BasketService(IBasketRepo basketRepo,IMapper mapper)
        {
            _basketRepo = basketRepo;
            _mapper = mapper;
        }


        public async  Task<BasketDTO> CreateOrUpdateBasketAsync(BasketDTO basket)
        {
            var basketconvert =_mapper.Map<CustomerBasket>(basket);
              var CreateBasket=await _basketRepo.CreateOrUpdateAsync(basketconvert);
            if (CreateBasket != null)
                return await GetBasketAsync(basket.Id);
            else
                throw new Exception("Not Create Or Update Basket ");
        }

        public async Task<bool> DeleteBasketAsync(string Key)
        {
          var DataDeleteBasket =  await _basketRepo.DeleteBasketAsync(Key);
            if (DataDeleteBasket)
                return true;
            else
                throw new BasketNotFoundException(Key);
        }



        public async Task<BasketDTO?> GetBasketAsync(string Key)
        {
            var DataBasket = await _basketRepo.GetBasketAsync(Key);
            if (DataBasket == null)
                throw new BasketNotFoundException(Key);
            var databasketconvert=_mapper.Map<BasketDTO>(DataBasket);
           
            return databasketconvert;
    }   }
}
