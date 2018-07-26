using Microsoft.VisualStudio.TestTools.UnitTesting;
using Waggle.Biz;

namespace UnitTests
{
    [TestClass]
    public class UnitTestProducts
    {
        [TestMethod]
        public void TestConstructorBasic()
        {

            //Arrange
            var product = new Product();
            product.ProductName = "Shimano Ultegra Di2";
            var expected = "Shimano Ultegra Di2";

            //Act
            var actual = product.ProductName;


            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestConstructorNameTooShort()
        {

            //Arrange
            var product = new Product();
            product.ProductName = "S";
            var expected = "Product Name must be between 3 and 30 characters long...";

            //Act

            var actual = product.ValidationMessage;


            //Assert
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestConstructorNameTooLong()
        {

            //Arrange
            var product = new Product();
            product.ProductName = "ProductName is longer than twenty characters..ProductName is longer than twenty characters..ProductName is longer than twenty characters..ProductName is longer than twenty characters..ProductName is longer than twenty characters..ProductName is longer than twenty characters..";
            var expected = "Product Name must be between 3 and 30 characters long...";

            //Act
            var actual = product.ValidationMessage;


            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestConstructorNameValid()
        {

            //Arrange
            var product = new Product();

            product.ProductName = "Valid Product Name";
            string expected = "Valid Product Name";
            string expectedMessage = null;


            //Act
            var actual = product.ProductName;
            string actualMessage = product.ValidationMessage;


            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }
}
