using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Waggle.cmn;

namespace Waggle.CmnTests
{
    [TestClass]
    public class StringHandlerTest
    {
        [TestMethod]
        public void InsertSpacesTest()
        {
            //Arrange
            var source = "SonicScrewdriver";
            var expected = "Sonic Screwdriver";

            

            //Act 
            var actual = source.InsertSpaces();
            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void InsertSpacesTestWithExistingSpace()
        {
            //Arrange
            var source = "Sonic Screwdriver";
            var expected = "Sonic Screwdriver";

            

            //Act 
            var actual = source.InsertSpaces();
            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void MakeAlphaNumericWithHyphenOnlyTest()
        {
            //Arrange
            var source = "Test-Thing!+";
            var expected = "Test-Thing";



            //Act 
            var actual = source.MakeAlphaNumericWithHyphenOnly();
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
