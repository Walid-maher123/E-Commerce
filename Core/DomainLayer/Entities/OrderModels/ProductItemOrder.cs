using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.OrderModels
{
    public class ProductItemOrder
    {
      

        public int ProductId { get; set; }


        public string ProductName { get; set; } = null!;


        public string PictureURL { get; set; } = null!;
       
    }
}
