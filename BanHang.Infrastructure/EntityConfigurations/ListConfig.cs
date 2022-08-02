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

    internal class ListConfig : IEntityTypeConfiguration<List>
    {
        public void Configure(EntityTypeBuilder<List> builder)
        {
            builder.HasKey(o => o.List_ID);
            builder.Property(o => o.List_ID);
            builder.Property(o => o.Order_ID);
            builder.Property(o => o.Product_ID);
        }
    }
}

