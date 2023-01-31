using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DAL.Entities
{
    public class SongGenre
    {
        public int Id { get; set; }
        public int SongId { get; set; }
        public int GenreId { get; set; }
        public virtual Song Song { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
