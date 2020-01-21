using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using TWH.Entities.Models;
using TWH.Repository;
using TWH.Services.Services;

namespace TWH.Services.Managers
{
    public class CustomerManager
    {
        public CustomerService customerService { get; set; }

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
            return customerService.GetAll().OrderBy(x => x.Lastname).ToList();
        }

        public Customer GetCustomerByEmail(string email)
        {
            var customers = customerService.SearchFor(x => x.Email == email).ToArray();
            if (customers.Length > 1)
            {
                //TODO fix here if more than 1 is found.
                Debug.WriteLine("There is more than 1 customer with the given email");
                return null;
            }
            else if(customers.Length < 1)
            {
                Debug.WriteLine("There is fewer than 1 customer with the given email");
                return null;
            }
            else
            {
                Debug.WriteLine(email);
                Debug.WriteLine(customers.FirstOrDefault().Email);
                Debug.WriteLine(customers.FirstOrDefault().postCode);
                return customers.FirstOrDefault();
            }
            
        }

        public Customer EditCustomer(Customer customer)
        {
            //temporary solution with the email, i did not have time to figure out why/where the Id was lost in transit.
            //this will lead to the email being non editable.
            var dbCustomer = customerService.SearchFor(x => x.Email == customer.Email).FirstOrDefault();
            Debug.WriteLine(dbCustomer.Lastname);
            Debug.WriteLine(customer.Lastname);
            if (dbCustomer != null)
            {
                Guid id = dbCustomer.Id;
                dbCustomer.Firstname = customer.Firstname;
                dbCustomer.Lastname = customer.Lastname;
                dbCustomer.Email = customer.Email;
                dbCustomer.PhoneNumber = customer.PhoneNumber;
                dbCustomer.postCode = customer.postCode;
                //cats should not be necessary to edit via this method.
                customerService.SaveChanges();
                return dbCustomer;
            }
            else
            {
                return null;
            }
            
        }
    }
}
