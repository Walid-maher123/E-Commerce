using SharedDataLayer.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstractionLayer.IServices
{
    public interface  IOrderSevice
    {
        Task<OrderDTO> CreateOrderAsync( string CustomerEmail,CreateOrderDTO createOrderDTO);

        Task<List<OrderDTO>?> GetAllOrderAsync(string Email);

        Task<OrderDTO?> GetOrderByIdAsync(string Emial, int Id);

        Task<List<DeliveryMetodDTO>?> GetAllDeliveryMetodAsync();
    }
}
