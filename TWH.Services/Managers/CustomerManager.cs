using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TWH.Entities.Models;
using TWH.Repository;
using TWH.Services.Services;

namespace TWH.Services.Managers
{
    class CustomerManager
    {
        public CustomerService customerService { get; set; };

        public CustomerManager(UnitOfWork unitOfWork)
        {
            customerService = new CustomerService(unitOfWork);
        }
        public IEnumerable<Customer> GetAll()
        {
            return customerService.GetAll();
        }
        //TODO look at this for ordering by, based on need.
        public IEnumerable<Customer> GetAllOrderedByName()
        {
            return customerService.GetAll().OrderBy(x => x.LastName).ToList();
        }
    }
}
