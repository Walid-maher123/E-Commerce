using DomainLayer.Entities.OrderModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistance.Cofigurations
{
    public class DeliveryMethodConfigure: IEntityTypeConfiguration<DeliveryMethod>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
            builder.Property(d => d.Cost).HasColumnType("decimal(8,2)");
            builder.Property(d => d.ShortName).HasMaxLength(50);
            builder.Property(d => d.Description).HasMaxLength(100);
            builder.Property(d => d.DeliveryTime).HasMaxLength(50);



        }
    }
}
