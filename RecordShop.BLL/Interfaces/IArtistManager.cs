using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Threading.Tasks;
using RecordShop.DAL.Entities;
using RecordShop.DAL.Models;

namespace RecordShop.BLL.Interfaces
{
    public interface IArtistManager
    {
        Task<ArtistInfoModel> GetJustArtistInfo(int id);
        Task<List<ArtistWithFirstNameAndLastNameModel>> Create(Artist artist);
        Task<List<ArtistWithFirstNameAndLastNameModel>> Update(Artist artist);
        Task<List<ArtistWithFirstNameAndLastNameModel>> Delete(Artist artist);
        Task<List<ArtistWithFirstNameAndLastNameModel>> GetAllWithoutArtistInfo();
    }
}