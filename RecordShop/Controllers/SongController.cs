using RecordShop.BLL.Interfaces;
using RecordShop.DAL.Entities;
using RecordShop.DAL.Interfaces;
using RecordShop.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecordShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongManager _songManager;
        
        public SongController(ISongManager songManager)
        {
            _songManager = songManager;
        }

        [HttpGet("GetAllSongs")]
        public async Task<IActionResult> GetAllSongs()
        {
            var songs = await _songManager.GetAllSongs();
            return Ok(songs);
        }

        [HttpPost("AddSong")]
        [Authorize("Admin")]
        public async Task<IActionResult> AddSong([FromBody] Song song)
        {
            if (string.IsNullOrEmpty(song.Name))
                return BadRequest("Name is null");
            
            if (song.Price == 0)
                return BadRequest("Price is 0");
            
            if (song.Duration == 0)
                return BadRequest("Duration is 0");

            var songs = await _songManager.Create(song);

            return Ok(songs);
        }

        [HttpPut("UpdateSong")]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateSong([FromBody] Song song)
        {
            var songs = await _songManager.Update(song);
            return Ok(songs);
        }

        [HttpDelete("DeleteSong")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteSong([FromBody] Song song)
        {
            var songs = await _songManager.Delete(song);
            return Ok(songs);
        }

        [HttpGet("GetSongsWithGenre/{genre}")]
        public async Task<IActionResult> GetSongsWithGenre([FromRoute] string genre)
        {
            var songs = await _songManager.GetSongsWithGivenGenre(genre);
            return Ok(songs);
        }

        [HttpGet("NoSongsWithGenre")]
        public async Task<IActionResult> NoSongsWithGenre()
        {
            var songs = await _songManager.GetGroupBy();
            return Ok(songs);
        }

        [HttpGet("GetSongsWithArtist/{idArtist}")]
        public async Task<IActionResult> GetSongsWithArtist([FromRoute] int idArtist)
        {
            var songs = await _songManager.GetSongsWithGivenArtist(idArtist);
            return Ok(songs);
        }

    }
}
