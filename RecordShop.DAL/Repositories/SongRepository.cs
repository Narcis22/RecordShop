using RecordShop.DAL.Entities;
using RecordShop.DAL.Interfaces;
using RecordShop.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DAL.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly AppDbContext _context;

        public SongRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Song song)
        {
            await _context.Songs.AddAsync(song);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Song song)
        {
            _context.Songs.Update(song);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Song song)
        {
            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Song> GetSongs()
        {
            var songs = _context.Songs;
            return songs;
        }

        public IQueryable<Song> GetSongsWithArtist()
        {
            var songs = _context.Songs
                .Include(x => x.Artist);

            return songs;
        }

        public IQueryable<SongGenre> GetSongsWithGenre()
        {
            var songs = _context.SongGenres
            .Include(x => x.Song)
            .Include(x => x.Genre);

            return songs;
        }
    }
}


