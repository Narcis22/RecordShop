using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecordShop.BLL.Interfaces;
using RecordShop.DAL.Interfaces;
using RecordShop.DAL.Entities;
using RecordShop.DAL.Models;

namespace RecordShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistManager _artistManager;

        public ArtistController(IArtistManager artistManager) 
        {
            _artistManager = artistManager;
        }

        [HttpPost("AddArtist")]
        [Authorize("Admin")]
        public async Task<IActionResult> AddArtist([FromBody] Artist artist)
        {
            if (string.IsNullOrEmpty(artist.LastName))
            {
                return BadRequest("Name is null");
            }
            var newArtists = await _artistManager.Create(artist);
            return Ok(newArtists);
        }

        [HttpPut("UpdateArtist")]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateArtist([FromBody] Artist artist)
        {
            var newArtists = await _artistManager.Update(artist);
            return Ok(newArtists);
        }

        [HttpDelete("DeleteArtist")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteArtist([FromBody] Artist artist)
        {
            var newArtists = await _artistManager.Delete(artist);
            return Ok(newArtists);
        }

        [HttpGet("GetArtists")]
        public async Task<IActionResult> GetArtists()
        {
            var artists = await _artistManager.GetAllWithoutArtistInfo();
            return Ok(artists);
        }

        [HttpGet("GetArtistInfo/{id}")]
        public async Task<IActionResult> GetArtistInfo([FromRoute] int id)
        {
            var artistInfo = await _artistManager.GetJustArtistInfo(id);
            return Ok(artistInfo);
        }
    }
}
