using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Tests
{
    [TestClass()]
    public class CountryDTOTests
    {
        [TestMethod()]
        public void CountryDTOAsAnEmptyObjectIsNotNull()
        {
            //arrange
            CountryDTO dto = new CountryDTO();
            //act
            //assert
            Assert.IsNotNull(dto);
        }

        [TestMethod()]
        public void CountryDTOAsAnObjectWithParameters()
        {
            //arrange
            byte[] image = { 1, 2 };
            CountryDTO dto = new CountryDTO(1,"test", "test", "test", "test",1,1, "test", "test", image);
            //act
            //assert
            Assert.IsNotNull(dto);
            Assert.AreEqual(1, dto.CountryID);
            Assert.AreEqual("test", dto.CountryName);
            Assert.AreEqual("test", dto.CountryCapital);
            Assert.AreEqual("test", dto.CountryCurrency);
            Assert.AreEqual("test", dto.CountryLanguage);
            Assert.AreEqual(1, dto.CountryArea);
            Assert.AreEqual(1, dto.CountryPopulation);
            Assert.AreEqual("test", dto.CountryRegime);
            Assert.AreEqual("test", dto.CountryInformation);
            Assert.AreEqual(image, dto.CountryFlag);
        }
    }
}