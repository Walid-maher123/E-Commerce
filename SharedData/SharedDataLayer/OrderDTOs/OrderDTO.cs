using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDataLayer.OrderDTOs
{
    public class OrderDTO
    {
        //Id , UserName , OrderDate , Items (Product Name - Picture Url - Price - Quantity) ,
        //Address ,
        //Delivery Method Name , Order Status Value , Sub Total , Total Price

        public int Id { get; set; }

        public string UserEmail { get; set; } = null!;

        public List<ItemsOrderDTO> Items { get; set; } = [];

        public AddressDTO ShipingAddress { get; set; } = null!;

        public string DeliveryMethodName { get; set; } = null!;

        public OrderStatusDTO Status {  get; set; }

        public decimal SubTotal { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
