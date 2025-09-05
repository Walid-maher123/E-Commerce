using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementationLayer.Exceptions
{
    public sealed class BasketNotFoundException(string Key) : NotFoundException($" The Key Of Basket {Key} Not Found")
    {
    }
}
