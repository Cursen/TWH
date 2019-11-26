using System;
using System.Collections.Generic;
using System.Text;
using TWH.Entities.Models;

namespace TWH.Repository
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        public CustomerRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
