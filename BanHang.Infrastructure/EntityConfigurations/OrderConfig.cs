using BanHang.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BanHang.Infrastructure.EntityConfigurations
{
    internal class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Order_ID);
            builder.Property(o => o.Order_ID);
            builder.Property(o => o.Date_Order);
            builder.Property(o => o.User_ID);
            builder.Property(o => o.Total_Cost);
            builder.Property(o => o.Discount);
        }
    }


}
