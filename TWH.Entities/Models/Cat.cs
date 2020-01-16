using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TWH.Entities.Models
{
    public class Cat : BaseEntityID<Guid>
    {
        //TODO set ranges. Consider DataAnnotations replacement.
        [StringLength(15, ErrorMessage = "Value of ChipID must be between 10-15.", MinimumLength = 10)]
        public string ChipID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Desc is required")]
        public string Desc { get; set; }
        //public Guid? ImageID { get; set; }
        //public virtual catImage Image { get; set; }
        public Cat()
        {
            Id = Guid.NewGuid();
        }        
    }
}
