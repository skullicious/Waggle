using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waggle.Biz;


namespace UnitTests
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        [TestMethod]
        public void RetrieveExisting()
        {

            //Arrange

            var customerRepository = new CustomerRepository();

            var expected = new Customer(1)
            {
                
                EmailAddress = "testuser@testtown.com",
                FirstName = "test",
                LastName = "user",
                                                            
            };



            //Act

            var actual = customerRepository.Retrieve(1);



            //Assert

            Assert.AreEqual(expected.CustomerId, actual.CustomerId);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.AreEqual(expected.EmailAddress, actual.EmailAddress);
        }



        [TestMethod]
        public void RetrieveExistingVendorWithAddress()
        {

            //Arrange

            var vendorRepository = new VendorRepository();

            var expected = new Vendor(5)
            {
                CompanyName = "Vendor Company",
                EmailAddress = "testvendor@testvendor.com",

            AddressList = new List<Address>()
                {
                    new Address()
                    {
                 AddressType = 2,
                StreetLine1 = "Vendorville",
                StreetLine2 = "",
                City = "Manhattan",
                State = "New York",
                Country = "USA",
                PostalCode = "NYC 123"
                    },
                    new Address()
                    {

                AddressType = 2,
                StreetLine1 = "SupplyLand",
                StreetLine2 = "",
                City = "Rajneesh",
                State = "Oregon",
                Country = "OGN",
                PostalCode = "OGN 456"

                    }
                }

            };



            //Act

            var actual = vendorRepository.Retrieve(5);



            //Assert

            Assert.AreEqual(expected.CompanyName, actual.CompanyName);
            Assert.AreEqual(expected.EmailAddress, actual.EmailAddress);

            for (int i=0; i <2; i++)
            {
                Assert.AreEqual(expected.AddressList[i].AddressType,actual.AddressList[i].AddressType);
                Assert.AreEqual(expected.AddressList[i].StreetLine1, actual.AddressList[i].StreetLine1);
                Assert.AreEqual(expected.AddressList[i].StreetLine2, actual.AddressList[i].StreetLine2);
                Assert.AreEqual(expected.AddressList[i].City, actual.AddressList[i].City);
                Assert.AreEqual(expected.AddressList[i].State, actual.AddressList[i].State);
                Assert.AreEqual(expected.AddressList[i].Country, actual.AddressList[i].Country);
                Assert.AreEqual(expected.AddressList[i].PostalCode, actual.AddressList[i].PostalCode);

            }
        }
    }
}
