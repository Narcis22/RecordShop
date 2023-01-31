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
    public class SongCartConfiguration : IEntityTypeConfiguration<SongCart>
    {
        public void Configure(EntityTypeBuilder<SongCart> builder)
        {
            builder.Property(p => p.NoCopies)
               .IsRequired();

            builder.HasOne(p => p.Song)
              .WithMany(p => p.SongCarts)
              .HasForeignKey(p => p.SongId);

            builder.HasOne(p => p.Cart)
                .WithMany(p => p.SongCarts)
                .HasForeignKey(p => p.CartId);
        }
    }
}
