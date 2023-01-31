using RecordShop.DAL.Entities;
using RecordShop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DAL.Interfaces
{
    public interface IGenreRepository
    {
        Task Create(Genre genre);
        Task Update(Genre genre);
        Task Delete(Genre genre);
        IQueryable<Genre> GetAll();
    }
}
