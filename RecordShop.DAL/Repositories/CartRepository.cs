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
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Cart> GetAllCarts()
        {
            return _context.Carts;
        }

        public IQueryable<SongCart> GetAllSongCarts()
        {
            return _context.SongCarts;
        }
        public IQueryable<SongCart> GetAllSongCartsIncludeSongAndCart()
        {
            return GetAllSongCarts()
                .Include(x => x.Song)
                .Include(x => x.Cart);
        }
        public IQueryable<Song> GetAllSongs()
        {
            return _context.Songs;
        }

        public async Task Create(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSongCart(Cart cart)
        {
            _context.Entry(cart).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task CreateSongCart(SongCart songCart)
        {
            await _context.SongCarts.AddAsync(songCart);
            await _context.SaveChangesAsync();
        }
    }
}
