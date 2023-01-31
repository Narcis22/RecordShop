using RecordShop.DAL.Entities;
using RecordShop.DAL.Interfaces;
using RecordShop.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DAL.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly AppDbContext _context;

        public ArtistRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Artist artist)
        {
            await _context.Artists.AddAsync(artist);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Artist artist)
        {
            _context.Artists.Update(artist);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Artist artist)
        {
            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Artist> GetAll()
        {
            var artist = _context.Artists;
            return artist;
        }

        public IQueryable<Artist> GetIncludeArtistInfo()
        {
            var info = GetAll().Include(x => x.ArtistInfo);
            return info;
        }

    }
}
