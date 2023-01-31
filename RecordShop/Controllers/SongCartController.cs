using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using RecordShop.BLL.Interfaces;
using RecordShop.DAL.Models;

namespace RecordShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongCartController : ControllerBase
    {

        private readonly ISongCartManager _songCartManager;
        
        public SongCartController(ISongCartManager songCartManager)
        {
            _songCartManager = songCartManager;
        }

        [HttpPost("AddSongCart/{songId}/{email}")]
        public async Task<IActionResult> AddSongCart([FromRoute] int songId, string email)
        {
            await _songCartManager.AddToSongCart(songId, email);
            return NoContent();
        }

        [HttpPut("IncreaseNoCopies")]
        public async Task<IActionResult> IncreaseNoCopies([FromBody] SongCartModel songCart)
        {
            var newSongCart = await _songCartManager.IncreaseSongCart(songCart);
            return Ok(newSongCart);
        }

        [HttpPut("DecreaseNoCopies")]
        public async Task<IActionResult> DecreaseNoCopies([FromBody] SongCartModel songCart)
        {
            var newSongCart = await _songCartManager.DecreaseSongCart(songCart);
            return Ok(newSongCart);
        }

        [HttpGet("GetSongCartForUser/{email}")]
        public async Task<List<SongCartModel>> GetSongCartForUser([FromRoute] string email)
        {
            var lista = await _songCartManager.GetSongCartForUser(email);
            return lista;
        }

        [HttpDelete("DeleteAllSongCartByEmail/{email}")]
        public async Task<IActionResult> DeleteAllSongCartByEmail([FromRoute] string email)
        {
            await _songCartManager.DeleteAllSongFromCart(email);
            return NoContent();
        }
    }
}

