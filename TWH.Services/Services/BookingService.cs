using System;
using System.Collections.Generic;
using System.Text;
using TWH.Repository;

namespace TWH.Services
{
    class BookingService : BaseService<BookingManager, Guid>
    {
        public BookingService(UnitOfWork unutOfWork) : base(UnitOfWork)
        {
            Repository = new BookingRepository(unitOfWork);
        }
    }
}
