using BanHang.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHang.Infrastructure.EntityConfigurations
{
    internal class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(o => o.Product_ID);
            builder.Property(o => o.Product_ID);
            builder.Property(o => o.Product_Name);
            builder.Property(o => o.Product_Number);
            builder.Property(o => o.Product_Detail);
            builder.Property(o => o.Price);
            builder.Property(o => o.Availability);

        }
    }
}
