using Microsoft.AspNetCore.Mvc;
using ServiceAbstractionLayer.IServices;
using SharedDataLayer.BasketDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Controller
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        [HttpPost]
        public async Task<ActionResult> CreateOrUpdateBasketAsync(BasketDTO basket)
        {
            if (!ModelState.IsValid) return BadRequest("not valid data");
            var databasket = await _basketService.CreateOrUpdateBasketAsync(basket);

            return Ok(databasket);
        }

        [HttpGet]

        public async Task<ActionResult> GetBasketAsync(string key)
        {
          var dataBasket= await  _basketService.GetBasketAsync(key);
            return Ok(dataBasket);
        }


        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteBasketAsync (string key)
        {
            var DeleteDataBAasket = await _basketService.DeleteBasketAsync(key);
            return DeleteDataBAasket;
        }


    }
}
