using DomainLayer.Entities.OrderModels;
using Presistance.Specificationmplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementationLayer.Specificationmplementation
{
    public class PaymentSpecification : Specification<Order,int >
    {
        public PaymentSpecification(string paymentintentid) :base(o=>o.PayMentIntentId==paymentintentid)
        {
             
        }
    }
}
