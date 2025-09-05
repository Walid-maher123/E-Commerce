using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDataLayer.OrderDTOs
{
    public class CreateOrderDTO
    {
        public string BasketId { get; set; } = null!;

        public AddressDTO ShipingAddress { get; set; } = null!;

        public int DeliveryMehodId { get; set; }

        
    }
}
