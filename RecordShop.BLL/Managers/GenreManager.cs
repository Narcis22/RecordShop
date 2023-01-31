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
    public class GenreManager : IGenreManager
    {
        private readonly IGenreRepository _genreRepository;

        public GenreManager(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<List<GenreModel>> Create(Genre genre)
        {

            var ok = _genreRepository
              .GetAll()
              .Where(x => x.Name == genre.Name).FirstOrDefault();

            if (ok == null)
                await _genreRepository.Create(genre);

            var cat = await GetAll();
            return cat;
        }

        public async Task<List<GenreModel>> Update(Genre categ)
        {

            var genre = await _genreRepository.GetAll().FirstOrDefaultAsync(x => x.Id == categ.Id);

            genre.Name = categ.Name;
            await _genreRepository.Update(genre);

            var cat = await GetAll();
            return cat;
        }

        public async Task<List<GenreModel>> DeleteNotUsedGenres()
        {
            var genreNotUsed = await _genreRepository.GetAll()
                                    .Where(x => !x.SongGenres.Any())
                                    .ToListAsync();

            foreach (var genre in genreNotUsed)
                await _genreRepository.Delete(genre);

            var cat = await GetAll();
            return cat;
        }

        public async Task<List<GenreModel>> GetAll()
        {
            var genres = await _genreRepository
                .GetAll()
                .Select(x => new GenreModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();

            return genres;
        }
    }
}
