using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Waggle.cmn;
using Waggle.Biz;
using System.Collections.Generic;

namespace Waggle.CmnTests
{
    [TestClass]
    public class LoggingServiceTest
    {
        [TestMethod]
        public void WriteToFileTest()
        {

            //Arrange

            var changedItems = new List<ILoggable>();


            var customer = new Customer(1)
            {
                EmailAddress = "email@email.com",
                FirstName = "first",
                LastName = "last",
                AddressList = null
            };
            changedItems.Add(customer as ILoggable);

            var product = new Product(2)
            {

                ProductName = "ultegra di-2 groupset",
                ProductDescription = "groupset",
                CurrentPrice = 800.00M

            };
            changedItems.Add(product as ILoggable);

            //Act
            LoggingService.WriteToFile(changedItems);


            //Assert
            //No assertion - create write to file so validate data
        }
    }
}
