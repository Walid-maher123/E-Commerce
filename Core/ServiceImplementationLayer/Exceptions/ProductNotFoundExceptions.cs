using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementationLayer.Exceptions
{
    public class ProductNotFoundExceptions(int id) :NotFoundException($"The Id {id} of Product Not Found")
    {
    }
}
