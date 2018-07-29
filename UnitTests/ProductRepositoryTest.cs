using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Waggle.Biz;


namespace UnitTests
{
    [TestClass]
    public class ProductRepositoryTest
    {
        [TestMethod]
        public void RetrieveExisting()
        {

            //Arrange

            var productRepository = new ProductRepository();

            var expected = new Product(1)
            {

                ProductName = "ultegra di-2 groupset",
                ProductDescription = "groupset",
                CurrentPrice = 800.00M
                
            };



            //Act

            var actual = productRepository.Retrieve(2);



            //Assert

            Assert.AreEqual(expected.ProductName, actual.ProductName);
            Assert.AreEqual(expected.ProductDescription, actual.ProductDescription);
            
        }


        [TestMethod]
        public void InsertExistingSQL()
        {

            //Arrange

            var productRepository = new ProductRepository();

            var dummyProduct = new Product()
            {

                ProductName = "ultegra di-2 groupset",
                ProductDescription = "groupset",
              

            };




            //Act

            var actual = productRepository;
            actual.InsertNewProduct(dummyProduct);


            //Assert

          

        }


        [TestMethod]
        public void RetrieveExistingProductSQL()
        {

            //Arrange
            var productRepository = new ProductRepository();

            var expected = new Product(1)
            {
                ProductName = "ultegra di-2 groupset",
                ProductDescription = "groupset",
            };


            //Act
            var result = productRepository;
            var actual = result.Retrieve(2);


            //Assert
            Assert.AreEqual(expected.ProductName, actual.ProductName);
            Assert.AreEqual(expected.ProductDescription, actual.ProductDescription);

        }

        [TestMethod]
        public void RetrieveProductListSQL()
        {

            //Arrange
            var productRepository = new ProductRepository();
            


            //Act
            var result = productRepository;
            var actual = result.Retrieve();


            //Assert
            
          foreach (var item in actual)
          {
              //Console.WriteLine(item.ProductId);
                Console.WriteLine(item.ProductName);
                Console.WriteLine(item.ProductDescription);

          }
          
        }
    }
}
