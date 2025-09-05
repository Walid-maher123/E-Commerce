using DomainLayer.Entities.ProductsModels;
using DomainLayer.ISpecificationAbstraction;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistance
{
    public static class SpecificationEvulator 
    {
        public  static IQueryable<TEntity> CreateQuery<TEntity, TKey>(IQueryable<TEntity> query , ISpecification<TEntity, TKey> specification) where TEntity : BaseEntity<TKey>
        {
            var Query = query;

           if (specification.Filteration!=null)
            {
                Query = Query.Where(specification.Filteration);
            }

           if(specification.Including!=null)
            {
              
                foreach( var i in specification.Including )
                    Query=Query.Include(i);
            }

           return Query;

        }
    }
}
