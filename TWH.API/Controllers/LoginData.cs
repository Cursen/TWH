using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TWH.API.Controllers
{
    public class LoginData : BaseController
    {
        public string Token { get; set; }
        public long TokenExpirationTime { get; set; }
        public Guid ID { get; set; }
    }
}
