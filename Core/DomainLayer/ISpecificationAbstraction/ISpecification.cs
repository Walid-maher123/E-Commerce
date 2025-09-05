using DomainLayer.Entities.ProductsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ISpecificationAbstraction
{
    public interface ISpecification<TEntity,TKey> where TEntity : BaseEntity<TKey>
    {
         Expression<Func<TEntity,bool>> Filteration { get; }

        List<Expression<Func<TEntity,object>>> Including { get; }
    }
}
