using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TWH.Entities
{
    public abstract class BaseEntityID<TEntityIdType>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TEntityIdType Id { get; set; }
    }
}
