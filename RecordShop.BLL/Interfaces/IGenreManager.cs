using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Threading.Tasks;
using RecordShop.DAL.Entities;
using RecordShop.DAL.Models;

namespace RecordShop.BLL.Interfaces
{
    public interface IGenreManager
    {
        Task<List<GenreModel>> Create(Genre genre);
        Task<List<GenreModel>> GetAll();
        Task<List<GenreModel>> Update(Genre genre);
        Task<List<GenreModel>> DeleteNotUsedGenres();
    }
}
