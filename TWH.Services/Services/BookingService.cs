using System;
using System.Collections.Generic;
using System.Text;
using TWH.Entities.Models;
using TWH.Repository;

namespace TWH.Services
{
    //TODO figure out is you are supposed to use "model object" and not Repository.
    public class BookingService : BaseService<Booking, Guid>
    {
        public BookingService(UnitOfWork unitOfWork) : base(unitOfWork)
        {
            Repository = new BookingRepository(unitOfWork);
        }
    }
}
