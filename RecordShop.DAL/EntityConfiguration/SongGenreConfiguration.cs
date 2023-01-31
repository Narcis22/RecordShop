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
    public class SongGenreConfiguration : IEntityTypeConfiguration<SongGenre>
    {
        public void Configure(EntityTypeBuilder<SongGenre> builder)
        {
            builder.HasOne(p => p.Song)
               .WithMany(p => p.SongGenres)
               .HasForeignKey(p => p.SongId);

            builder.HasOne(p => p.Genre)
                .WithMany(p => p.SongGenres)
                .HasForeignKey(p => p.GenreId);
        }

    }
}

