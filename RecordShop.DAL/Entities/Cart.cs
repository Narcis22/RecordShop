using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DAL.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public virtual ICollection<SongCart> SongCarts { get; set; }
        public int Sent { get; set; }
        public string UserEmail { get; set; }
    }
}