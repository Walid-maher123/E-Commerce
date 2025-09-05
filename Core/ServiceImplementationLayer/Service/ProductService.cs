using AutoMapper;
using DomainLayer;
using DomainLayer.Entities;
using DomainLayer.Entities.ProductsModels;
using DomainLayer.ISpecificationAbstraction;
using DomainLayer.RepositoryAbstraction;
using Presistance.Specificationmplementation;
using ServiceAbstractionLayer.IServices;
using ServiceImplementationLayer.AutoMappers;
using ServiceImplementationLayer.Exceptions;
using SharedDataLayer.ProductData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementationLayer.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork,IMapper mapper)
        {
           _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // Get All Product 
        public async Task<IEnumerable<ProductDTO>> GetAllProductAsync(int? BrandId, int? TypeId)
        {
            var specification = new ProductSpecification(BrandId, TypeId);
            var data = await  _unitOfWork.Repository<Product,int>(). GetAllAsync(specification);
            return _mapper.Map<List<ProductDTO>>(data);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductAsync()
        {
            var data = await _unitOfWork.Repository<Product, int>().GetAllAsync();
            return _mapper.Map<List<ProductDTO>>(data);
        }



        // Get product By id 
        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            var specification = new ProductSpecification(id);
            var data = await _unitOfWork.Repository<Product, int>().GetByIdAsync(specification);
            if (data == null)
                throw new ProductNotFoundExceptions(id);
            return _mapper.Map<ProductDTO>(data);
        }

        // GetAllBrand
        public async Task<IEnumerable<BrandDTO>> GetAllBrandAsync()
        {
          var data = await _unitOfWork.Repository<ProductBrand, int>().GetAllAsync();
           return  _mapper.Map<List<BrandDTO>>(data);
        }


        //GetAllType
        public async Task<IEnumerable<TypeDTO>> GetAllTypeAsync()
        {
           var data = await _unitOfWork.Repository<ProductType, int>().GetAllAsync();
            return _mapper.Map<List<TypeDTO>>(data);
        }

       
    }
}
