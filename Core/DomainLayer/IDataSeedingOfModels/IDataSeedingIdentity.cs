using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.IDataSeeding
{
    public interface IDataSeedingIdentity
    {
       public Task DataSeedIdentityAsync();
    }
}
