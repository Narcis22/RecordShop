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
    public class ArtistInfoConfiguration : IEntityTypeConfiguration<ArtistInfo>
    {
        public void Configure(EntityTypeBuilder<ArtistInfo> builder)
        {
            builder.Property(p => p.Nationality)
                .HasColumnType("nvarchar(128)")
                .HasMaxLength(128);
        }
    }
}
