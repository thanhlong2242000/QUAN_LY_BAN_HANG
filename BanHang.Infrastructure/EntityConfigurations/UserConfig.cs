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
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(o => o.User_ID);
            builder.Property(o => o.User_ID);
            builder.Property(o => o.User_Name);
            builder.Property(o => o.Age);
            builder.Property(o => o.Sex);
            builder.Property(o => o.Phone);
            builder.Property(o => o.Role);

        }
    }
}
