using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDataLayer.BasketDTO
{
    public class BasketDTO
    {
        public string Id {  get; set; }

        public ICollection<BasketItemDTO> Items { get; set; } = [];
        public string? PaymentIntentId { get; set; }

        public int? DeliveriedMethodId { get; set; }

        public string? ClientSecret { get; set; }
    }
}
