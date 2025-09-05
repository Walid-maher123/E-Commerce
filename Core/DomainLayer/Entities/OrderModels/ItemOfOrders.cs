using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.Xml;
using DomainLayer.Entities.ProductsModels;

namespace DomainLayer.Entities.OrderModels
{
    public class ItemOfOrders:BaseEntity<int>
    {


        public ProductItemOrder productItemOrder { get; set; } = null!;
       

        public decimal Price { get; set; }

        public int Quantity {  get; set; }

    }
}
