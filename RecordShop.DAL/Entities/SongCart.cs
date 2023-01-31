using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DAL.Entities
{
    public class SongCart
    {
        public int Id { get; set; }
        public int SongId { get; set; }
        public int CartId { get; set; }
        public virtual Song Song { get; set; }
        public virtual Cart Cart { get; set; }
        public int NoCopies { get; set; }
    }
}

