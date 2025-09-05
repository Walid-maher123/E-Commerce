using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDataLayer.OrderDTOs
{
    public class DeliveryMetodDTO
    {
        public int Id { get; set; }
        public string ShortName { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string DeliveryTime { get; set; } = null!;

        public decimal Cost { get; set; }
    }
}
