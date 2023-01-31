using RecordShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DAL.Interfaces
{
    public interface ISongCartRepository
    {
        IQueryable<SongCart> GetAllSongCarts();
        IQueryable<SongCart> GetAllSongCartsIncludeCarts();
        IQueryable<SongCart> GetAllSongCartsIncludeCartsAndSongs();
        IQueryable<Cart> GetAllCarts();
        Task CreateSongCart(SongCart songCart);
        Task UpdateSongCart(SongCart songCart);
        Task Delete(SongCart songCart);
    }
}
