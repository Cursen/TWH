using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TWH.Entities.Models;
using TWH.Services.Managers;

namespace TWH.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CustomerController : BaseController
    {
        private CustomerManager customerManager;

        public CustomerController()
        {
            customerManager= new CustomerManager(unitOfWork);
        }
        [HttpGet]
        [Route("getcustomerbyemail")]
        public IActionResult GetCustomerByEmail(string email)
        {
            //TODO fix customer manager return call incase of error.
            return Ok(customerManager.GetCustomerByEmail(email));
        }
        [HttpPost]
        [Route("editCustomer")]
        public IActionResult EditCustomer([FromBody] Customer customer)
        {
            Debug.WriteLine(customer.Id);
            return Ok(customerManager.EditCustomer(customer));
        }
    }
}
