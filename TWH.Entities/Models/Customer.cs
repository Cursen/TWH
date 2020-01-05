using System;
using System.Collections.Generic;
using System.Text;

namespace TWH.Entities.Models
{
    public class Customer : BaseEntityID<Guid>
    {
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public LinkedList<Cat> Cats { get; set; }
    }
}
