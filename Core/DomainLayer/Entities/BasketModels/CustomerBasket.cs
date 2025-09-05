using DomainLayer.Entities.ProductsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.BasketModels
{
    public class CustomerBasket :BaseEntity<string>
    {
     
        public ICollection<BasketItem> Items { get; set; } = [];

        public string? PaymentIntentId { get; set; }

        public int ? DeliveriedMethodId { get; set; }    

        public string? ClientSecret { get; set; }
        
    } 
}
