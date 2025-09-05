using DomainLayer.Entities.OrderModels;
using Presistance.Specificationmplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementationLayer.Specificationmplementation
{
    public class OrderSpecification :Specification<Order,int>
    {
        public OrderSpecification(string email): base(O=>O.UserEmail==email)
        {
            Including.Add(o => o.DeliveryMethod);
            Including.Add(o => o.Items);
        }
        public OrderSpecification(string Email ,int Id ):base(o=>o.Id==Id&& o.UserEmail==Email)
        {
            Including.Add(o => o.DeliveryMethod);
            Including.Add(o => o.Items);
        }
    }
}
