using DomainLayer.Entities.ProductsModels;
using ServiceImplementationLayer.Specificationmplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistance.Specificationmplementation
{
    public class ProductSpecification : Specification<Product,int>
    {
        public ProductSpecification(int? BrandId ,int? TypeId) :
            base(p=>!(BrandId.HasValue)||(p.ProductBrandId==BrandId)&&
            (!TypeId.HasValue)||(p.ProductTypeId==TypeId))
        {
            AddIncluding(p => p.ProductType);
            AddIncluding(p => p.ProductBrand);
        }





        // Get By id 
        public ProductSpecification(int id) :base(p=>p.Id==id)
        {
            AddIncluding(p => p.ProductType);
            AddIncluding(p => p.ProductBrand);
        }
    }
}
