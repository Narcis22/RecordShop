using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DAL.Models
{
    public class SongModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Duration { get; set; }
        public int Year { get; set; }
        public int Remix { get; set; }
        public string Album { get; set; }
    }
}
