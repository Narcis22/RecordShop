using RecordShop.DAL.Entities;
using RecordShop.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DAL.Interfaces
{
    public interface IArtistRepository
    {
        Task Create(Artist artist);
        Task Update(Artist artist);
        IQueryable<Artist> GetAll();
        IQueryable<Artist> GetIncludeArtistInfo();
        Task Delete(Artist artist);
    }
}
