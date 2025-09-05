using DomainLayer.Entities.ProductsModels;
using DomainLayer.ISpecificationAbstraction;
using DomainLayer.RepositoryAbstraction;
using Presistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistance.RepositoryImplementation
{
    public class GenericRepo<TEntity, TKey>: IGenericRepo<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly StoreDbContext _storeDbContext;

        public GenericRepo(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }
        // Get All 
        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity, TKey> specification)
        {
            var Data = SpecificationEvulator.CreateQuery(_storeDbContext.Set<TEntity>(), specification);
            return await Data.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
         return await _storeDbContext.Set<TEntity>().ToListAsync();
        }

        // Get By Id
        public async Task<TEntity?> GetByIdAsync(ISpecification<TEntity, TKey> specification)
        {
            var Data = await SpecificationEvulator.CreateQuery(_storeDbContext.Set<TEntity>(), specification).FirstOrDefaultAsync();

            return Data;

        }

        public async Task<TEntity?> GetByIdAsync(TKey Id)
        {
            return await _storeDbContext.Set<TEntity>().FindAsync(Id);

        }



        // Add 
        public async Task AddAsync(TEntity entity)
        {
           await _storeDbContext.Set<TEntity>().AddAsync(entity);
        }



        // Delete
        public async Task DeleteAsync(TEntity entity)
        {
             _storeDbContext.Set<TEntity>().Remove(entity);
        }

      

        
        //Update
        public async Task UpdateAsync(TEntity entity)
        {
           _storeDbContext.Set<TEntity>().Update(entity);
        }

       
    }
}
