using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Tests
{
    [TestClass()]
    public class COVIDDTOTests
    {
        [TestMethod()]
        public void COVIDDTOAsAnEmptyObjectIsNotNull()
        {
            //arrange
            CountryDTO dto = new CountryDTO();
            //act
            //assert
            Assert.IsNotNull(dto);
        }
    }
}