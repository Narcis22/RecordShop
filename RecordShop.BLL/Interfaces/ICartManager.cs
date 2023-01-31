using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Threading.Tasks;
using RecordShop.DAL.Entities;
using RecordShop.DAL.Models;

namespace RecordShop.BLL.Interfaces
{
    public interface ICartManager
    {
        List<int> GetCartId(string email);
        Task AddCartToUser(string email);
        List<string> GetStringSongCartModel(string email);
        PriceModel CartPrice(int cartId);
        Task UpdateSentCart(string email);
    }
}
