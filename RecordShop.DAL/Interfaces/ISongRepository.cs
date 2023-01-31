using RecordShop.DAL.Entities;
using RecordShop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DAL.Interfaces
{
    public interface ISongRepository
    {
        Task Create(Song song);
        Task Update(Song song);
        Task Delete(Song song);
        IQueryable<Song> GetSongs();
        IQueryable<Song> GetSongsWithArtist();
        IQueryable<SongGenre> GetSongsWithGenre();
    }
}
