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
    public class ArtistManager : IArtistManager
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistManager(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public async Task<List<ArtistWithFirstNameAndLastNameModel>> Create(Artist artist)
        {
            var ok = _artistRepository
                .GetAll()
                .Where(x => x.FirstName == artist.FirstName && x.LastName == artist.LastName).FirstOrDefault();

            if (ok == null)
            {
                await _artistRepository.Create(artist);
            }

            var artists = await GetAllWithoutArtistInfo();
            return artists;
        }

        public async Task<List<ArtistWithFirstNameAndLastNameModel>> GetAllWithoutArtistInfo()
        {
            var auth = await _artistRepository
                .GetAll()
                .Select(x => new ArtistWithFirstNameAndLastNameModel { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName }).ToListAsync();
            return auth;
        }

        public async Task<ArtistInfoModel> GetJustArtistInfo(int id)
        {
            var info = await _artistRepository
                 .GetIncludeArtistInfo()
                 .Where(x => x.Id == id)
                 .Select(x => new ArtistInfoModel { Nationality = x.ArtistInfo.Nationality, BirthYear = x.ArtistInfo.BirthYear, DeathYear = x.ArtistInfo.DeathYear })
                 .FirstOrDefaultAsync();

            if (info == null)
            {
                info = new ArtistInfoModel { };
            }
            return info;
        }

        public async Task<List<ArtistWithFirstNameAndLastNameModel>> Update(Artist artist)
        {
            await _artistRepository.Update(artist);

            var artists = await GetAllWithoutArtistInfo();
            return artists;
        }

        public async Task<List<ArtistWithFirstNameAndLastNameModel>> Delete(Artist artist)
        {
            await _artistRepository.Delete(artist);

            var artists = await GetAllWithoutArtistInfo();
            return artists;
        }
    }

}
