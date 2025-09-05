using DomainLayer;
using DomainLayer.Entities.OrderModels;
using DomainLayer.Entities.ProductsModels;
using DomainLayer.RepositoryAbstraction;
using Presistance.Contexts;
using Presistance.RepositoryImplementation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _storeDbContext;

        private Hashtable _repository;
        public UnitOfWork(StoreDbContext storeDbContext)
        {
           _storeDbContext = storeDbContext;
            _repository = new Hashtable();
        }

        public IGenericRepo<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var type = typeof(TEntity).Name;
            if(!_repository.ContainsKey(type))
            {
                var Repository = new GenericRepo<TEntity, TKey>(_storeDbContext);
                _repository.Add(type, Repository);
            }

            return _repository[type] as IGenericRepo<TEntity, TKey>;
        }

        public async Task SaveChange()
        {
            await _storeDbContext.SaveChangesAsync();
        }




    }
}
