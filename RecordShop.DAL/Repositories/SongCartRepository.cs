using RecordShop.DAL.Entities;
using RecordShop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DAL.Repositories
{
    public class SongCartRepository : ISongCartRepository
    {

        private readonly AppDbContext _context;

        public SongCartRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateSongCart(SongCart songCart)
        {
            await _context.AddAsync(songCart);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(SongCart songCart)
        {
            _context.SongCarts.Remove(songCart);
            await _context.SaveChangesAsync();
        }

        public IQueryable<SongCart> GetAllSongCarts()
        {
            return _context.SongCarts;
        }

        public IQueryable<SongCart> GetAllSongCartsIncludeCarts()
        {
            var songcarts = GetAllSongCarts().Include(x => x.Cart);
            return songcarts;
        }

        public IQueryable<SongCart> GetAllSongCartsIncludeCartsAndSongs()
        {
            var songcarts = GetAllSongCartsIncludeCarts().Include(x => x.Song);
            return songcarts;
        }
        public IQueryable<Cart> GetAllCarts()
        {
            return _context.Carts;
        }

        public async Task UpdateSongCart(SongCart songCart)
        {
            _context.SongCarts.Update(songCart);
            await _context.SaveChangesAsync();
        }
    }
}
