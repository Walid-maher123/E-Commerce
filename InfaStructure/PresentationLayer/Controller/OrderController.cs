using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstractionLayer.IServices;
using SharedDataLayer.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Controller
{
    [ApiController]
    [Route("api/[Controller]")]
    public class OrderController :ControllerBase
    {
        private readonly IOrderSevice _orderSevice;

        public OrderController(IOrderSevice orderSevice)
        {
            _orderSevice = orderSevice;
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateOrderAsync(CreateOrderDTO createOrder)
        {
            var Email =  User.FindFirstValue(ClaimTypes.Email);
            var dataorder =await _orderSevice.CreateOrderAsync( Email,createOrder);
            if (dataorder == null) return BadRequest("SomeError");
            return Ok(dataorder);
        }
        [HttpGet]
        [Authorize]

        public async Task<ActionResult> GetAllOrderAsync()
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);
            var DataOrder=await _orderSevice.GetAllOrderAsync(Email);
            if (DataOrder == null) return NotFound("The Orders Not Found");
            return Ok(DataOrder);
        }

        [HttpGet("{Id}")]
        [Authorize]
        public async Task<ActionResult> GetOrderbyIdAsync([FromRoute]int Id)
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);
            var DataOrder = await _orderSevice.GetOrderByIdAsync(Email, Id);
            if (DataOrder == null) return NotFound("The Order Not Found");
            return Ok(DataOrder);
        }

        [HttpGet("GetDelivery")]
        [Authorize]
        public async Task<ActionResult> GetAllDeliveryMetodAsync()
        {
           var Data =await _orderSevice.GetAllDeliveryMetodAsync();
            if (Data == null) return NotFound("Not Found Data Of Delivery");
            return Ok(Data);
        }

    }
}
