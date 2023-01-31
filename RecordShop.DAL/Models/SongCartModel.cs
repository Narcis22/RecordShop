using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DAL.Models
{
    public class SongCartModel
    {
        public int SongId { get; set; }
        public int CartId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int NoCopiesInCart { get; set; }
        public float PriceOfNoCopies { get; set; }
    }
}
