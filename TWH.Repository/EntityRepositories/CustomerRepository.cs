using System;
using System.Collections.Generic;
using System.Text;
using TWH.Entities.Models;

namespace TWH.Repository
{
    public class CustomerRepository : BaseRepository<Customer, Guid>
    {
        public CustomerRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
