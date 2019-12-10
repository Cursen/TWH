using System;
using System.Collections.Generic;
using System.Text;
using TWH.Entities.Models;
using TWH.Repository;

namespace TWH.Services.Services
{
    public class CustomerService : BaseService<Customer, Guid>
    {
        public CustomerService(UnitOfWork unitOfWork) : base(unitOfWork)
        {
            Repository = new CustomerRepository(unitOfWork);
        }
    }
}
