using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DAL.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Duration { get; set; }
        public int Year { get; set; }
        public int Remix { get; set; }
        public string Album { get; set; }
        public virtual ICollection<SongGenre> SongGenres { get; set; }
        public int? ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual ICollection<SongCart> SongCarts { get; set; }

    }
}
