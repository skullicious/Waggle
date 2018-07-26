using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waggle;
using Waggle.Biz;

namespace Waggle.biz.Tests
{
    [TestClass()]
    public class OrderRepositoryTests
    {
        [TestMethod()]
        public void RetrieveOrderDisplayTest()
        {


            //Arrange

            var orderRepository = new OrderRepository();

            var expected = new OrderDisplay()

            {
                FirstName = "Damien",
                LastName = "Sweeney",
                OrderDate = new DateTimeOffset(2018, 6, 10, 0, 0, 0, new TimeSpan(-6, 0, 0)),
                ShippingAddress = new Address()
                {
                    AddressType = 1,
                    StreetLine1 = "12 Catherine Howard Close",
                    StreetLine2 = "",
                    City = "Thetford",
                    State = "Norfolk",
                    Country = "United Kingdom",
                    PostalCode = "IP24 1TQ"
                },
                orderDisplayItemList = new List<OrderDisplayItem>()
                {
                  new OrderDisplayItem()
                  {
                    ProductName = "Butt Butter Chamois Cream",
                    PurchasePrice = 20.00m,
                    OrderQuantity = 5
                  },
                  new OrderDisplayItem()
                  {
                     ProductName = "Wiggle Electrolytes",
                     PurchasePrice = 2.00m,
                     OrderQuantity = 12
                  }
                }
            };

            //Act

            var actual = orderRepository.RetrieveOrderDisplay(10);


            //Assert
            
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.AreEqual(expected.OrderDate, actual.OrderDate);


            Assert.AreEqual(expected.ShippingAddress.AddressType, actual.ShippingAddress.AddressType);
            Assert.AreEqual(expected.ShippingAddress.StreetLine1, actual.ShippingAddress.StreetLine1);
            Assert.AreEqual(expected.ShippingAddress.StreetLine2, actual.ShippingAddress.StreetLine2);
            Assert.AreEqual(expected.ShippingAddress.City, actual.ShippingAddress.City);
            Assert.AreEqual(expected.ShippingAddress.State, actual.ShippingAddress.State);
            Assert.AreEqual(expected.ShippingAddress.Country, actual.ShippingAddress.Country);
            Assert.AreEqual(expected.ShippingAddress.PostalCode, actual.ShippingAddress.PostalCode);

         for (int i = 0; i < 2; i++)
               {              
               Assert.AreEqual(expected.orderDisplayItemList[i].ProductName, actual.orderDisplayItemList[i].ProductName);
               Assert.AreEqual(expected.orderDisplayItemList[i].OrderQuantity, actual.orderDisplayItemList[i].OrderQuantity);
               Assert.AreEqual(expected.orderDisplayItemList[i].PurchasePrice, actual.orderDisplayItemList[i].PurchasePrice);
               }

           


        }



        


       
       
    }
}