using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using TWH.Entities;
using TWH.Entities.Models;
using TWH.Repository;
using TWH.Services;
using TWH.Services.Managers;
using TWH.Services.Services;

namespace TWH.UnitTests
{
    [TestClass]
    public class UnitTestsCustomer
    {
        public void printCustomer(Customer customer)
        {
            Debug.WriteLine(customer);
            Debug.WriteLine($"Customer: ID:{customer.Id} Email: {customer.Email} Cats: {customer.Cats}"); 
        }
        [TestMethod]
        public void CustomerCatListCanBeEmpty()
        {
            //Arrange
            var unitOfWork = new UnitOfWork();
            var manager = new CustomerManager(unitOfWork);
            List<Cat> cats = new List<Cat>();
            var customer = new Customer { Email = "fakeName@123456FakeMail.com", Firstname = "Martin", Lastname = "XORQ", PhoneNumber = "8898989898", Address = "123fakes", Cats = cats, postCode = "6633" };
            var cat = new Cat { ChipID = "11111111111", Name = "Mittens", Desc = "Grumpy, old, Black" };
            //Act
            manager.AddCustomer(customer);
            customer.Cats.Add(cat);
            manager.EditCustomer(customer);
            //Assert
            var storedCustomer = manager.GetCustomerByEmail(customer.Email);
            printCustomer(customer);
            printCustomer(storedCustomer);
            Assert.AreEqual(storedCustomer, customer);
        }
        //TODO consider implementing a specific Error class for this.
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void CatsEditOnNull()
        {
            //Arrange
            var unitOfWork = new UnitOfWork();
            var manager = new CustomerManager(unitOfWork);
            var customer = new Customer { Email = "fakeName@123FakeMail.com", Firstname = "Martin", Lastname = "XORQ", PhoneNumber = "8898989898", Address = "123fakes", Cats = null, postCode = "3355" };
            var cat = new Cat { ChipID = "11111111111", Name = "Mittens", Desc = "Grumpy, old, Black" };
            //Act
            manager.AddCustomer(customer);
            customer.Cats.Add(cat);
            manager.EditCustomer(customer);
            //Assert
            //EditCustomer throwing NullReferenceExcpetion is the assertion of this test.
        }
        [TestMethod]
        public void EmailHasToBeUniquie()
        {
            //Arrange
            var unitOfWork = new UnitOfWork();
            var manager = new CustomerManager(unitOfWork);
            var customer1 = new Customer { Email = "bjorn@1234567FakeMail.com", Firstname = "Ulf", Lastname = "Dahl", PhoneNumber = "9263318861", Address = "123fakestreet", Cats = null, postCode = "5566" };
            var customer2 = new Customer { Email = "bjorn@1234567FakeMail.com", Firstname = "Martin", Lastname = "XORQ", PhoneNumber = "8898989898", Address = "123fakes", Cats = null, postCode = "2233" };
            //Act
            Boolean added = manager.AddCustomer(customer1);
            Boolean added2 = manager.AddCustomer(customer2);
            var customers = manager.GetAll();
            foreach(var c in customers)
            {
                printCustomer(c);
            }
            //Assert
            Assert.IsFalse(added2);
            Assert.IsTrue(added);
        }
        //This test should test the logic postcode being valid and its reaction.
        [TestMethod]
        public void TestPostCodeValid()
        {
            //Arrange
            var unitOfWork = new UnitOfWork();
            var manager = new CustomerManager(unitOfWork);
            var customer = new Customer { Email = "gunnar44@123459FakeMail.com", Firstname = "Ulf", Lastname = "Dahl", PhoneNumber = "9263318861", Address = "123fakestreet", Cats = null, postCode = "2211" };
            //Act
            manager.AddCustomer(customer);
            var editedPostcode = "4477";
            customer.postCode = editedPostcode;
            manager.EditCustomer(customer);
            var storedCustomer = manager.GetCustomerByEmail(customer.Email);
            //Assert
            Assert.AreEqual(storedCustomer.postCode,editedPostcode);
        }
        //This test should test the logic of a postcode not being valid and its reaction.
        [TestMethod]
        public void TestPostCodeIsNotValidInsert()
        {
            //Arrange
            var unitOfWork = new UnitOfWork();
            var manager = new CustomerManager(unitOfWork);
            var customer = new Customer { Email = "fakeName@1Fake.com", Firstname = "Martin", Lastname = "XORQ", PhoneNumber = "8898989898", Address = "123fakes", Cats = null, postCode = "99 88" };
            var customer2 = new Customer { Email = "fakeName2@1Fake.com", Firstname = "Martin", Lastname = "XORQ", PhoneNumber = "8898989898", Address = "123fakes", Cats = null, postCode = "99889" };
            var customer3 = new Customer { Email = "fakeName@1Fake.com", Firstname = "Martin", Lastname = "XORQ", PhoneNumber = "8898989898", Address = "123fakes", Cats = null, postCode = "a988" };
            //Act
            var successes = new List<Boolean>();
            successes.Add(manager.AddCustomer(customer));
            successes.Add(manager.AddCustomer(customer2));
            successes.Add(manager.AddCustomer(customer3));
            //Assert
            foreach(var s in successes)
            {
                Assert.IsFalse(s);
            }
        }
        [TestMethod]
        public void TestPostCodeIsNotValidEdit()
        {
            //Arrange
            var unitOfWork = new UnitOfWork();
            var manager = new CustomerManager(unitOfWork);
            var customer = new Customer { Email = "fakeName@1Faal.com", Firstname = "Martin", Lastname = "XORQ", PhoneNumber = "8898989898", Address = "123fakes", Cats = null, postCode = "7744" };
            //Act
            manager.AddCustomer(customer);
            var editedPostcode = "112";
            customer.postCode = editedPostcode;
            var success = manager.EditCustomer(customer);
            //Assert

            Assert.IsFalse(success);
        }
        [TestMethod]
        public void TestCatsAdd()
        {
            //Arrange
            var unitOfWork = new UnitOfWork();
            var manager = new CustomerManager(unitOfWork);
            //Act

            //Assert
        }
        [TestMethod]
        public void TestCatsRemove()
        {
            //Arrange
            var unitOfWork = new UnitOfWork();
            var manager = new CustomerManager(unitOfWork);
            //Act

            //Assert
        }
        [TestMethod]
        public void TestCatsEdit()
        {
            //Arrange
            var unitOfWork = new UnitOfWork();
            var manager = new CustomerManager(unitOfWork);
            //Act

            //Assert
        }
    }
}
