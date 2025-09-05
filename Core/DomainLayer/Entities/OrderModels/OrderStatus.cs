using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.OrderModels
{
    public enum OrderStatus
    {
        Pending =1,
        PaymentReceived,
        PaymentFailed
    }
}
