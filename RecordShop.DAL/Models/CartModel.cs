using RecordShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DAL.Models
{
    public class CartModel
    {
        public List<string> SongModels { get; set; }
        public string CartPrice { get; set; }
    }
}
