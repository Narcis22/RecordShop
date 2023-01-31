using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Threading.Tasks;
using RecordShop.DAL.Entities;
using RecordShop.DAL.Models;

namespace RecordShop.BLL.Interfaces
{
    public interface ISongCartManager
    {
        int GetCartId(string email);
        Task DeleteAllSongFromCart(string email);
        Task AddToSongCart(int songId, string email);
        Task<List<SongCartModel>> GetSongCartForUser(string email);
        Task<List<SongCartModel>> IncreaseSongCart(SongCartModel songCart);
        Task<List<SongCartModel>> DecreaseSongCart(SongCartModel songCart);
    }
}
