using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            else if (customers.Length < 1)
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
        //TODO change the return style to deal with errors instead of returning passive info when something is wrong, like try and catch etc.
        public Boolean EditCustomer(Customer customer)
        {
            try {
                var dbCustomer = customerService.SearchFor(x => x.Email == customer.Email).FirstOrDefault();
                    if (dbCustomer != null)
                    {
                        if (customerValidator(dbCustomer))
                        {
                            dbCustomer.Firstname = customer.Firstname;
                            dbCustomer.Lastname = customer.Lastname;
                            dbCustomer.Email = customer.Email;
                            dbCustomer.PhoneNumber = customer.PhoneNumber;
                            dbCustomer.postCode = customer.postCode;
                            //cats should not be necessary to edit via this method.
                            customerService.SaveChanges();
                            return true;
                        }
                        else
                        {
                            Trace.WriteLine("Postcode is false");
                            Debug.WriteLine("Postcode is false");
                            Console.WriteLine("postcode is false");
                            return false;
                        }
                    }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine("Error in edit");
                return false;
            }
        }
        //Quick fix for validation pre Insert/Edit Only postcode is shown for here to be used as a example of 4 digit numbers, but one can at least extend it later. Perhaps look into validation patterns.
        private Boolean customerValidator(Customer customer)
        {
            var postCodeValidator = new Regex(@"\d{4}");
            if (postCodeValidator.IsMatch(customer.postCode))
            {
                return true;
            }
            else
            {
                Debug.WriteLine($"{customer.postCode} is False");
                return false;
            }
        }
        //TODO change the return style to deal with errors instead of returning passive info when something is wrong, like try and catch etc.
        //For now it follows the "minimum" requirement to meet the UnitTest for it, aka it returns true if it worked
        public Boolean AddCustomer(Customer customer)
        {
            try{
                if (customer != null)
                {
                    if (customerValidator(customer))
                    {
                        if (!customerService.Any(x => x.Email == customer.Email))
                        {
                            customerService.Insert(customer);
                            return true;
                        }
                        else
                        {
                            Debug.WriteLine($"there is more than one email registered too: {customer.Email}");
                            return false;
                        }
                    }
                }
                Debug.WriteLine("False returned in Add Customer");
                return false;
            }
            catch
            {
                Trace.WriteLine("Error in Insert");
                return false;
            }
        }
    }
}
