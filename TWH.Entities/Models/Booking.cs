using System;
using System.Collections.Generic;
using System.Text;

namespace TWH.Entities.Models
{
    public class Booking : BaseEntityID<Guid>
    {
        //TODO store cats food selection, how do you deal with several rooms, different dates being booked by a customer.
        public virtual Customer customer { get; set; }
        public virtual LinkedList<Cat> cats { get; set; }
        public virtual Room bookedRoom { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public DateTime bookinDate { get; set; }
    }
}
