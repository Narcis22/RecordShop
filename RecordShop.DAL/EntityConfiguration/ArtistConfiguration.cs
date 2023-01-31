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
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.Property(p => p.FirstName)
                .HasColumnType("nvarchar(128)")
                .HasMaxLength(128);

            builder.Property(p => p.LastName)
                .HasColumnType("nvarchar(128)")
                .HasMaxLength(128)
                .IsRequired();
        }
    }
}
