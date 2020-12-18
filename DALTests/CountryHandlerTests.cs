using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL.Tests
{
    [TestClass()]
    public class CountryHandlerTests
    {
        private CountryDTO c;
        private CountryHandler handler;

        [TestInitialize()]
        public void Setup()
        {
            c = new CountryDTO();
            handler = new CountryHandler();
        }


        [TestMethod()]
        public void GetCountryTestOnUKIDWithCapitalLondon()
        {
            //arrange
            int UKID = 2;
            string UKCapital = "London";
            //act
            c = handler.GetCountry(UKID);
            //assert
            Assert.IsNotNull(c);
            Assert.AreEqual(UKCapital, c.CountryCapital);
        }

        [TestMethod()]
        public void GetAllCountriesTest()
        {
            List<CountryDTO> listA = new List<CountryDTO>();

            //arrange
            int countryCount = 43;
            //act
            listA = handler.GetAllCountries();
            //assert
            Assert.IsNotNull(listA);
            Assert.AreEqual(countryCount, listA.Count());
        }

        [TestMethod()]
        public void GetCountryWhereCountryISNULL()
        {
            //arrange
            int ID = 0;
            //act
            c = handler.GetCountry(ID);
            //assert
            Assert.IsNull(c);
        }
    }
}