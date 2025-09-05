using DomainLayer.Entities.ProductsModels;
using DomainLayer.ISpecificationAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.RepositoryAbstraction
{
    public interface IGenericRepo<TEntity,TKey> where TEntity : BaseEntity<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity,TKey> specification);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task <TEntity> GetByIdAsync(ISpecification<TEntity, TKey> specification);
        public  Task<TEntity?> GetByIdAsync(TKey Id);


        Task AddAsync (TEntity entity);

        Task DeleteAsync (TEntity entity);

        Task UpdateAsync (TEntity entity);
    }
}
