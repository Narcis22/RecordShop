using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using RecordShop.BLL.Interfaces;
using RecordShop.DAL.Interfaces;
using RecordShop.DAL.Entities;
using RecordShop.DAL.Models;

namespace RecordShop.BLL.Managers
{
    public class CartManager : ICartManager
    {
        private readonly ICartRepository _cartRepository;

        public CartManager(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task AddCartToUser(string email)
        {
            var cart = _cartRepository
              .GetAllCarts()
              .Where(x => x.UserEmail == email && x.Sent == 0).FirstOrDefault();

            if (cart == null)
            {
                cart = new Cart { Sent = 0, UserEmail = email };
                await _cartRepository.Create(cart);
            }
        }

        public List<int> GetCartId(string email)
        {
            var idCart = _cartRepository
                .GetAllCarts()
                .Where(x => x.UserEmail == email && x.Sent == 1)
                .Select(x => x.Id)
                .ToList();

            return idCart;
        }

        public PriceModel CartPrice(int cartId)
        {
            var OrderPrice = _cartRepository.GetAllSongCartsIncludeSongAndCart()
                .Where(x => x.Cart.Id == cartId)
                .Sum(y => y.Song.Price * y.NoCopies);

            var str = new PriceModel {
                Price = $"Order total: {OrderPrice}"
            };

            return str;
        }

        public List<string> GetStringSongCartModel(string email)
        {
            var ids = GetCartId(email);

            var strings = new List<string>();

            foreach (var id in ids)
            {
                var model = _cartRepository.GetAllSongCarts()
                    .Where(x => x.CartId == id)
                    .Join(_cartRepository.GetAllSongs(), b => b.SongId, a => a.Id, (b, a) =>
                     new SongCartModel
                     {
                         Name = a.Name,
                         Price = a.Price,
                         NoCopiesInCart = b.NoCopies,
                         PriceOfNoCopies = a.Price * b.NoCopies
                     });

                string modelString = "";

                foreach (var str in model)
                {
                    modelString = modelString + 
                        $"Song name: {str.Name}; \nPrice per cpoy: {str.Price} $;\n" +
                        $"Number of copies purchased: {str.NoCopiesInCart}; \n" +
                        $"Price: {str.PriceOfNoCopies} $ \n";
                }
                modelString = modelString + CartPrice(id).Price + " \n";
                strings.Add(modelString);
            }

            return strings;
        }

        public async Task UpdateSentCart(string email)
        {
            var cart = _cartRepository.GetAllCarts()
                .Where(x => x.UserEmail == email && x.Sent == 0)
                .FirstOrDefault();

            if (cart != null)
            {
                cart.Sent = 1;
                await _cartRepository.UpdateSongCart(cart);
            }
        }
    }
}
