using SharedDataLayer.BasketDTO;
using SharedDataLayer.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstractionLayer.IServices
{
    public interface  IPaymentService

    {
        Task<BasketDTO> CreateOrUpdatePaymentAsync(string BasketId);

        Task<OrderDTO> UpdatePaymentintentSucceedOrFailed(string PaymentintentId, bool Flag);
    }
}
