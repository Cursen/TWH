using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TWH.Entities.Models
{
    public class Booking : BaseEntityID<Guid>
    {
        //TODO store cats food selection, how do you deal with several rooms, different dates being booked by a customer.
        public virtual Customer customer { get; set; }
        public virtual ICollection<Cat> cats { get; set; }
        public virtual Room bookedRoom { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public DateTime? bookingDate { get; set; }
        public string bookedByUser { get; set; }
        //both payment options are expected to be in pence, and not 20.50£, and should have a quick calculation in the presentation layer instead.
        public int amountToPay { get; set; }
        public int amountPayed { get; set; }
        public string foodType { get; set; }
        public Boolean cctvEnabled { get; set; }
        
        public Booking()
        {
            cats = new List<Cat>();
        }
    }
}
