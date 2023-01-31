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
    public class SongManager : ISongManager
    {
        private readonly ISongRepository _songRepository;

        public SongManager(ISongRepository songRepository)
        {
            _songRepository = songRepository;
        }

        public async Task<List<SongModel>> Create(Song song)
        {
            await _songRepository.Create(song);

            var newList = await GetAllSongs();
            return newList;
        }

        public async Task<List<SongModel>> Update(Song song)
        {
            await _songRepository.Update(song);

            var newList = await GetAllSongs();
            return newList;
        }

        public async Task<List<SongModel>> Delete(Song song)
        {
            await _songRepository.Delete(song);

            var newList = await GetAllSongs();
            return newList;
        }

        public async Task<List<SongModel>> GetSongsWithGivenGenre(string genre)
        {
            var songs = await _songRepository
                .GetSongsWithGenre()
                .Where(x => x.Genre.Name == genre)
                .Select(x => new SongModel
                {
                    Id = x.Song.Id,
                    Name = x.Song.Name,
                    Price = x.Song.Price,
                    Duration = x.Song.Duration,
                    Year = x.Song.Year,
                    Remix = x.Song.Remix,
                    Album = x.Song.Album
                })
                .ToListAsync();

            return songs;
        }

        public async Task<List<SongModel>> GetSongsWithGivenArtist(int idArtist)
        {
            var songs = await _songRepository
                .GetSongsWithArtist()
                .Where(x => x.Artist.Id == idArtist)
                .Select(x => new SongModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Duration = x.Duration,
                    Year = x.Year,
                    Remix = x.Remix,
                    Album = x.Album
                })
                .ToListAsync();
            return songs;
        }

        public async Task<List<SongModel>> GetAllSongs()
        {
            var songs = await _songRepository.GetSongs()
                .Select(x => new SongModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Duration = x.Duration,
                    Year = x.Year,
                    Remix = x.Remix,
                    Album = x.Album
                })
                .OrderBy(x => x.Name)
                .ToListAsync();
            return songs;
        }

        public async Task<List<NoSongsWithGenreModel>> GetGroupBy()
        {
            var grouped = await _songRepository.GetSongsWithGenre()
                .GroupBy(x => x.Genre.Name)
                .Select(x => new NoSongsWithGenreModel
                {
                    Name = x.Key,
                    Num = x.Count()
                })
                .OrderByDescending(x => x.Num)
                .ToListAsync();

            return grouped;
        }
    }
}
