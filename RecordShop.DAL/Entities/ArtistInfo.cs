using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DAL.Entities
{
    public class ArtistInfo
    {
        public int Id { get; set; }
        public string Nationality { get; set; }
        public int? BirthYear { get; set; }
        public int? DeathYear { get; set; }
        public int? ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
