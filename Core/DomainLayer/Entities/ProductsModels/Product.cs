using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.ProductsModels
{
    public class Product :BaseEntity<int>
    { 
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string PictureURL { get; set; } = null!;

        public decimal Price { get; set; }

        public int? ProductBrandId { get; set; }
        public ProductBrand? ProductBrand { get; set; } = null!;

        public int? ProductTypeId { get; set; }
        public ProductType? ProductType { get; set; } = null!;
    }
}
