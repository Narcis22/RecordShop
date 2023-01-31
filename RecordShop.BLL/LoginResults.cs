using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Threading.Tasks;

namespace RecordShop.BLL
{
    public class LoginResult
    {
        public string AccessToken { get; set; }
        public bool Success { get; set; }
        public string RefreshToken { get; set; }
    }
}
