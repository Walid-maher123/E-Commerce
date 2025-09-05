using DomainLayer.Entities.ProductsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.OrderModels
{
    public class Order:BaseEntity<int>
    {
       

        public string UserEmail { get; set; } = null!;

        public DateTime OrderDate {  get; set; }= DateTime.Now;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public Address ShipingAddress { get; set; } = null!;

        public DeliveryMethod? DeliveryMethod { get; set; } = null!;

        public ICollection<ItemOfOrders> Items { get; set; } = new HashSet<ItemOfOrders>();  

        public decimal SubTotal { get; set; }

        public string? PayMentIntentId { get; set; }
        public decimal TotalPrice() => (SubTotal + (DeliveryMethod?.Cost) ??0 );




    }
}
