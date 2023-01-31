using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Threading.Tasks;
using System.Security.Claims;
using RecordShop.DAL.Entities;
using RecordShop.DAL.Repositories;
using RecordShop.BLL.Interfaces;

namespace RecordShop.BLL.Interfaces
{
    public interface ITokenHelper
    {
        string CreateRefreshToken();
        Task<string> CreateAccessToken(User user);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string _Token);
    }
}
