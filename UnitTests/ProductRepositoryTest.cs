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
        public void InsertNewProductSQL()
        {

            //Arrange

            var productRepository = new ProductRepository();

            var dummyProduct = new Product()
            {

                ProductName = "Test Product mk2",
                ProductDescription = "Description of the product",
                EntityState = EntityStateOption.Test,
                Category = "GS",
                SequenceNumber = 0123456789,
                

            };
            
            //Act

            var actual = productRepository;
            actual.InsertNewProduct(dummyProduct);
            
            //Assert

          

        }



        [TestMethod]
        public void UpdateExistingProductSQL()
        {
            var productRepository = new ProductRepository();

            var currentProduct = productRepository.Retrieve(12);
                        
            currentProduct.ProductDescription = "Description Test Updater!";
                    
            productRepository.UpdateExistingProduct(currentProduct);

        }


        [TestMethod]
        public void UpdateEntityStateForProductSQL()
        {
            var productRepository = new ProductRepository();

            var currentProduct = productRepository.Retrieve(12);

            currentProduct.EntityState = EntityStateOption.Deleted;          

            
            productRepository.UpdateExistingProduct(currentProduct);

        }


        [TestMethod]
        public void RetrieveExistingProductSQL()
        {

            //Arrange
            var productRepository = new ProductRepository();

            var expected = new Product(1)
            {
                ProductName = "Test Product mk2",
                ProductDescription = "Description Test Updater",
            };


            //Act
            var result = productRepository;
            var actual = result.Retrieve(12);


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
                Console.WriteLine(item.ProductCode);
                Console.WriteLine(item.ProductName);
                Console.WriteLine(item.ProductDescription);

          }
          
        }
    }
}
