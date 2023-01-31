using RecordShop.BLL.Interfaces;
using RecordShop.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecordShop.Controllers
{
    /// <summary>
    /// No need for DELETE method, carts are temporary and emptied at the end of the session
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartManager _cartManager;

        public CartController(ICartManager cartManager)
        {
            _cartManager = cartManager;
        }

        [HttpPost("AddCartToUser/{email}")]
        public async Task<IActionResult> AddCartToUser([FromRoute] string email)
        {
            await _cartManager.AddCartToUser(email);
            return NoContent();
        }

        [HttpGet("CartPrice/{cartId}")]
        public async Task<IActionResult> CartPrice([FromRoute] int cartId)
        {
            if (cartId == 0)
                return BadRequest("Id is 0.");

            var str = _cartManager.CartPrice(cartId);

            return Ok(str);
        }

        [HttpGet("GetStringSongCart/{email}")]
        public async Task<List<string>> GetStringSongCart([FromRoute] string email)
        {
            var listaString = _cartManager.GetStringSongCartModel(email);
            return listaString;
        }

        [HttpPut("UpdateSentCart/{email}")]
        public async Task<IActionResult> UpdateSentCart([FromRoute] string email)
        {
            await _cartManager.UpdateSentCart(email);
            return NoContent();
        }

        [HttpGet("GetCartId/{email}")]
        public async Task<IActionResult> GetCartId([FromRoute] string email)
        {
            var str = _cartManager.GetCartId(email);
            return Ok(str);
        }
    }
}
