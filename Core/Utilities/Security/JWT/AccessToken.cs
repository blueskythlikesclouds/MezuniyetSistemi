using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        // Sifrelenmis jwt token degeri
        public string Token { get; set; }
        // Gecerlilik tarihi
        public DateTime Expiration { get; set; }
    }
}
