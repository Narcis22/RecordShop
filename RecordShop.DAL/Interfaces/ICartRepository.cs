using RecordShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DAL.Interfaces
{
    public interface ICartRepository
    {
        IQueryable<Cart> GetAllCarts();
        IQueryable<SongCart> GetAllSongCarts();
        IQueryable<SongCart> GetAllSongCartsIncludeSongAndCart();
        IQueryable<Song> GetAllSongs();
        Task Create(Cart cart);
        Task UpdateSongCart(Cart cart);
        Task CreateSongCart(SongCart songCart);
    }
}
