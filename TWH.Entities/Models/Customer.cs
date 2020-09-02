using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TWH.Entities.Models
{
    public class Customer : BaseEntityID<Guid>
    {
        [StringLength(50,ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Firstname is required")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Lastname is required")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "PhoneNumber is required")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        public virtual ICollection<Cat> Cats { get; set; }
        [Required(ErrorMessage = "Postcode is required")]
        public string postCode { get; set; }
        public Customer()
        {
            Cats = new List<Cat>();
        }
    }
}
