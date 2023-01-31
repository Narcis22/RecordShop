using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecordShop.BLL.Interfaces;
using RecordShop.DAL.Interfaces;
using RecordShop.DAL.Entities;
using RecordShop.DAL.Models;

namespace RecordShop.BLL.Managers
{
    public class SongCartManager : ISongCartManager
    {

        private readonly ISongCartRepository _songCartRepository;

        public SongCartManager(ISongCartRepository songCartRepository)
        {
            _songCartRepository = songCartRepository;
        }

        public async Task AddToSongCart(int songId, string email)
        {
            var songCart = _songCartRepository.GetAllSongCartsIncludeCarts()
                .Where(x => x.SongId == songId && x.Cart.UserEmail == email && x.Cart.Sent == 0).FirstOrDefault();

            if (songCart == null)
            {
                var cartId = GetCartId(email);

                var NewSongCart = new SongCart
                {
                    SongId = songId,
                    CartId = cartId,
                    NoCopies = 1
                };

                await _songCartRepository.CreateSongCart(NewSongCart);
            }
        }

        public async Task<List<SongCartModel>> IncreaseSongCart(SongCartModel songcart)
        {
            var songCart = _songCartRepository.GetAllSongCartsIncludeCartsAndSongs()
                .Where(x => x.Song.Id == songcart.SongId && x.Cart.Id == songcart.CartId && x.Cart.Sent == 0).FirstOrDefault();

            songCart.NoCopies = songCart.NoCopies + 1;

            await _songCartRepository.UpdateSongCart(songCart);

            var newSongCart = await GetSongCartForUser(songCart.Cart.UserEmail);
            return newSongCart;
        }

        public int GetCartId(string email)
        {
            var idCart = _songCartRepository
                .GetAllCarts()
                .Where(x => x.UserEmail == email && x.Sent == 0)
                .Select(x => x.Id)
                .FirstOrDefault();

            return idCart;
        }

        public async Task<List<SongCartModel>> DecreaseSongCart(SongCartModel songcart)
        {
            var songCart = _songCartRepository.GetAllSongCartsIncludeCartsAndSongs()
                .Where(x => x.Song.Id == songcart.SongId && x.Cart.Id == songcart.CartId && x.Cart.Sent == 0)
                .FirstOrDefault();

            if (songCart.NoCopies - 1 > 0)
            {
                songCart.NoCopies = songCart.NoCopies - 1;
                await _songCartRepository.UpdateSongCart(songCart);
            }
            else
                await _songCartRepository.Delete(songCart);

            var newSongCart = await GetSongCartForUser(songCart.Cart.UserEmail);
            
            return newSongCart;
        }

        public async Task DeleteAllSongFromCart(string email)
        {
            var cart = await _songCartRepository
                .GetAllSongCartsIncludeCarts()
                .Where(x => x.Cart.UserEmail == email && x.Cart.Sent == 0).ToListAsync();

            foreach (var comanda in cart)
            {
                await _songCartRepository.Delete(comanda);
            }
        }

        public async Task<List<SongCartModel>> GetSongCartForUser(string email)
        {
            var songCart = await _songCartRepository.GetAllSongCartsIncludeCartsAndSongs()
                .Where(x => x.Cart.UserEmail == email && x.Cart.Sent == 0)
                .Select(x => new SongCartModel
                {
                    SongId = x.SongId,
                    CartId = x.CartId,
                    Name = x.Song.Name,
                    Price = x.Song.Price,
                    NoCopiesInCart = x.NoCopies,
                    PriceOfNoCopies = x.Song.Price * x.NoCopies
                })
                .ToListAsync();
            return songCart;
        }

    }
}
