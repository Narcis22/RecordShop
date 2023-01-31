using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Threading.Tasks;
using RecordShop.DAL.Entities;
using RecordShop.DAL.Models;

namespace RecordShop.BLL.Interfaces
{
    public interface ISongManager
    {
        Task<List<SongModel>> Create(Song song);
        Task<List<SongModel>> GetAllSongs();
        Task<List<SongModel>> GetSongsWithGivenGenre(string genre);
        Task<List<SongModel>> GetSongsWithGivenArtist(int idArtist);
        Task<List<NoSongsWithGenreModel>> GetGroupBy();
        Task<List<SongModel>> Update(Song song);
        Task<List<SongModel>> Delete(Song song);

    }
}
