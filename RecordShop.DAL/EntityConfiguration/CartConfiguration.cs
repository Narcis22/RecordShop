using RecordShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DAL.EntityConfiguration
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.Property(p => p.Sent)
                .HasMaxLength(1)
                .IsRequired();
            builder.Property(p => p.UserEmail)
                .HasColumnType("nvarchar(128)")
                .HasMaxLength(128)
                .IsRequired();
        }
    }
}
