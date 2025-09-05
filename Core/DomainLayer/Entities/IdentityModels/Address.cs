using DomainLayer.Entities.ProductsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.IdentityModels
{
    public class Address :BaseEntity<int>
    {
       

        public string FName { get; set; } = null!;

        public string LName { get; set; } = null!;

        public string Street { get; set; } = null!;

        public string City { get; set; } = null!;

        public string Country { get; set; } = null!;
    }
}
