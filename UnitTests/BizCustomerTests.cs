using Microsoft.VisualStudio.TestTools.UnitTesting;
using Waggle.Biz;

namespace UnitTests
{
    [TestClass]
    public class UnitTestCustomers
    {
        [TestMethod]
        public void TestCustomerFullNameProperty()
        {

            //Arrange
            Customer customer = new Customer();
            customer.FirstName = "FirstName";
            customer.LastName = "LastName";
            string expected = "LastName, FirstName";

            //Act
            string actual = customer.FullName;


            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCustomerEmptyFirstName()
        {

            //Arrange
            Customer customer = new Customer();
         
            customer.LastName = "LastName";
            string expected = "LastName";

            //Act
            string actual = customer.FullName;


            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCustomerEmptyLastName()
        {

            //Arrange
            Customer customer = new Customer();
            customer.FirstName = "FirstName";           
            string expected = "FirstName";

            //Act
            string actual = customer.FullName;


            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StaticTest()
        {

            //Arrange
            var customer1 = new Customer();
            customer1.FirstName = "Alvin";
            Customer.InstanceCount += 1;

            var customer2 = new Customer();
            customer2.FirstName = "Simon";
            Customer.InstanceCount += 1;

            var customer3 = new Customer();
            customer3.FirstName = "Theodore";
            Customer.InstanceCount += 1;

            var expected = 3;


            //Act
            var actual = Customer.InstanceCount;


            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void ValidateValid()
        {

            //Arrange
            var customer = new Customer();
            customer.LastName = "Smith";
            customer.EmailAddress = "j.smith@email.com";
            
            var expected = true;

            //Act
            var actual = customer.Validate();
            
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateMissingEmail()
        {

            //Arrange
            var customer = new Customer();
            customer.LastName = "Smith";
          
            var expected = false;
            
            //Act
            var actual = customer.Validate();
            
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateMissingLastName()
        {
            //Arrange
            var customer = new Customer();
            customer.EmailAddress = "j.smith@email.com";
          

            var expected = false;

            //Act
            var actual = customer.Validate();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateMissingBothFields()
        {

            //Arrange
            var customer = new Customer();
          //no fields set.
            var expected = false;

            //Act
            var actual = customer.Validate();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
