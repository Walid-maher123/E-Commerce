using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDataLayer.BasketDTO
{
    public class BasketItemDTO
    {
        public int Id { get; set; }
        
        public string ProductName { get; set; } = null!;

      
        public string PictureURL { get; set; } = null!;
        [Range(1,double.MaxValue)]
        public decimal Price { get; set; }
        [Range(1, 10)]
        public int Quantity { get; set; }
    }
}
