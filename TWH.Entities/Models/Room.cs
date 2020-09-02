using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TWH.Entities.Models
{
    public class Room : BaseEntityID<Guid>
    {
        [Required(ErrorMessage ="Room Number is required")]
        public int Number { get; set; }
        [Required(ErrorMessage = "Max amount of cats is required")]
        public int MaxCats { get; set; }
    }
}
