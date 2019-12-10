using System;
using System.Collections.Generic;
using System.Text;

namespace TWH.Entities.Models
{
    public class Booking : BaseEntityID<Guid>
    {
        //TODO store cats food selection, how do you deal with several rooms, different dates being booked by a customer.
        public Guid ID { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual LinkedList<Cat> Cats { get; set; }
        public virtual Room BookedRoom { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
