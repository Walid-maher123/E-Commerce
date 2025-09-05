using DomainLayer.Entities.OrderModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistance.Cofigurations
{
    public class OrderItemConfigure : IEntityTypeConfiguration<ItemOfOrders>
    {
        public void Configure(EntityTypeBuilder<ItemOfOrders> builder)
        {
            builder.Property(o => o.Price).HasColumnType("decimal(8,2)");
            builder.OwnsOne(o => o.productItemOrder, owned =>
            {
                owned.Property(p => p.ProductId).HasColumnName("ProductId");
                owned.Property(p => p.ProductName).HasColumnName("ProductName");
                owned.Property(p => p.PictureURL).HasColumnName("PictureURL");
            });
        }
    }
}
