using DomainLayer.Entities.ProductsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.BasketModels
{
    public class BasketItem: BaseEntity<int>
    {
       
     

        public string ProductName { get; set; } = null!;
        

        public string PictureURL { get; set; } = null!;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

    }
}
