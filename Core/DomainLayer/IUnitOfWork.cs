using DomainLayer.Entities.OrderModels;
using DomainLayer.Entities.ProductsModels;
using DomainLayer.RepositoryAbstraction;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public interface IUnitOfWork
    {
        IGenericRepo<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;

        Task SaveChange();
    }
}
