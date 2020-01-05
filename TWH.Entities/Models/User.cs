using System;
using System.Collections.Generic;
using System.Text;

namespace TWH.Entities.Models
{
    public class User : BaseEntityID<Guid>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
