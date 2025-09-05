using DomainLayer.Entities.ProductsModels;
using DomainLayer.ISpecificationAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementationLayer.Specificationmplementation
{
    public abstract class Specification<TEntity, TKey> : ISpecification<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        // Filteration 
        public Expression<Func<TEntity, bool>> Filteration { get; private set; }

        protected Specification(Expression<Func<TEntity,bool>> filter)
        {
            Filteration = filter;
        }

        // Including 
        public List<Expression<Func<TEntity, object>>> Including { get; private set; } = [];

        public void AddIncluding (Expression<Func<TEntity,object>> including)
        {
            Including.Add(including);
        }
    }
}
