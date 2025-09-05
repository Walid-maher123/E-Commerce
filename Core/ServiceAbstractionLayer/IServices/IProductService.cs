using SharedDataLayer.ProductData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstractionLayer.IServices
{
    public  interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProductAsync(int? BrandId, int? TypeId);
        Task<IEnumerable<ProductDTO>> GetAllProductAsync();

        Task<ProductDTO> GetProductByIdAsync( int id);

       Task<IEnumerable<BrandDTO>> GetAllBrandAsync();
       Task<IEnumerable<TypeDTO>> GetAllTypeAsync();
      
    }
}
