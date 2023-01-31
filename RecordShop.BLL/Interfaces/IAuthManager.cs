using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Threading.Tasks;
using RecordShop.DAL.Entities;
using RecordShop.DAL.Models;

namespace RecordShop.BLL.Interfaces
{
    public interface IAuthManager
    {
        Task<LoginResult> Login(LoginModel loginModel);
        Task<bool> Register(RegisterModel registerModel);
        Task<string> Refresh(RefreshModel refreshModel);
    }
}
