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
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.Property(p => p.Name)
                .HasColumnType("nvarchar(256)")
                .IsRequired();

            builder.Property(p => p.Price)
                .HasColumnType("decimal(5,2)")
                .IsRequired();

            builder.Property(p => p.Duration)
                .IsRequired();

            builder.Property(p => p.Album)
                 .HasColumnType("nvarchar(128)")
                 .HasMaxLength(100);
        }
    }
}
