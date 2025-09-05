using DomainLayer.Entities.ProductsModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistance.Cofigurations
{
    public class ProductConfigure : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
     
            builder.Property(p => p.Price).HasColumnType("decimal(8,2)");
            builder.HasOne(p=>p.ProductBrand).WithMany(p => p.Products)
                .HasForeignKey(p=>p.ProductBrandId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.ProductType).WithMany(p => p.Products)
               .HasForeignKey(p => p.ProductTypeId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
