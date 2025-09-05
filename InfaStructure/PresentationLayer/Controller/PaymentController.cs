using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceAbstractionLayer.IServices;
using SharedDataLayer.OrderDTOs;
using Stripe;
using Stripe.V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PresentationLayer.Controller
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _payment;

        public PaymentController(IPaymentService payment)
        {
            _payment = payment;
        }

        [HttpPost("{basketId}")]
        [Authorize]
        public async Task<ActionResult> CreatePayment(string basketId)
        {

            var Basket = await _payment.CreateOrUpdatePaymentAsync(basketId);
            if (Basket== null) return BadRequest("Some Error in Paymet");

            return Ok(Basket);
        }
        const string endpointSecret = "51ebf1abb2269955b347ce985446e4f37a421472dc5";

        [HttpPost("webhook")]
        public async Task<ActionResult> Index()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            
            try
            {
                var stripeSignature = Request.Headers["Stripe-Signature"];
                var stripeEvent = EventUtility.ConstructEvent(json, stripeSignature, endpointSecret);
               var paymentintent= stripeEvent.Data.Object as PaymentIntent;
                OrderDTO orderDTO = default;
                if (stripeEvent.Type == "payment_intent.succeeded")
                {
                    orderDTO= await _payment.UpdatePaymentintentSucceedOrFailed(paymentintent.Id, true);
                }
                else if (stripeEvent.Type == "payment_intent.payment_failed")
                {
                    orderDTO = await _payment.UpdatePaymentintentSucceedOrFailed(paymentintent.Id, false);

                }

                return Ok(orderDTO);
            }
            catch (StripeException e)
            {
                Console.WriteLine($"❗ Stripe error: {e.Message}");
                return BadRequest();
            }
        }
    }

}
    

