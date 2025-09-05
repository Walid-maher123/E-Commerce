using DomainLayer.Entities.OrderModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Presistance.Cofigurations
{
    public class OrderConfigure : IEntityTypeConfiguration<Order>
    {

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.SubTotal).HasColumnType("decimal(8,2)");

            builder.HasMany(i => i.Items).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(i => i.DeliveryMethod).WithMany().OnDelete(DeleteBehavior.NoAction);

            builder.OwnsOne(A => A.ShipingAddress, A => A.WithOwner());
        }
    }
}
