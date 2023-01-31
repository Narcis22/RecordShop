using RecordShop.BLL.Interfaces;
using RecordShop.DAL;
using RecordShop.DAL.Entities;
using RecordShop.DAL.Interfaces;
using RecordShop.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecordShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreManager _genreManager;

        public GenreController(IGenreManager genreManager)
        {
            _genreManager = genreManager;
        }

        [HttpPost("AddGenre")]
        [Authorize("Admin")]
        public async Task<IActionResult> AddGenre([FromBody] Genre genre)
        {
            if (string.IsNullOrEmpty(genre.Name))
            {
                return BadRequest("Name is null");
            }

            var cat = await _genreManager.Create(genre);
            return Ok(cat);
        }

        [HttpPut("UpdateGenre")]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateGenre([FromBody] Genre genre)
        {
            if (genre.Id == 0)
            {
                return BadRequest("Id is 0");
            }

            var cat = await _genreManager.Update(genre);
            return Ok(cat);
        }

        [HttpDelete("DeleteGenres")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteGenres()
        {
            var cat = await _genreManager.DeleteNotUsedGenres();

            return Ok(cat);
        }

        [HttpGet("GetGenres")]
        public async Task<IActionResult> GetGenres()
        {
            var lista_cat = await _genreManager.GetAll();
            return Ok(lista_cat);
        }
    }
}
