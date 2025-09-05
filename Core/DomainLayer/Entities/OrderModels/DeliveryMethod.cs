using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using DomainLayer.Entities.ProductsModels;

namespace DomainLayer.Entities.OrderModels
{
    public class DeliveryMethod:BaseEntity<int>
    {
      

        public string ShortName { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string DeliveryTime { get; set; } = null!;

        public decimal Cost { get; set; }
    }
}
