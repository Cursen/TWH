using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TWH.Entities.Models
{
    public class Cat : BaseEntityID<Guid>
    {
        //TODO set ranges. Consider DataAnnotations replacement.
        public Guid ID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [Range(10, 15, ErrorMessage = "Value of ChipID must be between 10-15.")]
        public int ChipID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public virtual CatImage Image { get; set; }
            
    }
}
