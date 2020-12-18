using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Logic.Tests
{
    [TestClass()]
    public class CountryTests
    {
        private Country c;
        private List<Country> listA;
        [TestInitialize()]
        public void Setup()
        {
            c = new Country();
            listA = new List<Country>();
        }

        [TestMethod()]
        public void CountryAsAnEmptyObjectIsNotNull()
        {
            Assert.IsNotNull(c);
        }

        [TestMethod()]
        public void CountryAsAnObjectWithParameters()
        {
            byte [] image = { 1, 2, 3 };
            //arrange
            Country country = new Country(2, "test", "test", "test", "test", 1, 1, "test", "test", image);
            //act
            //assert
            Assert.IsNotNull(country);
            Assert.AreEqual(2, country.CountryID);
            Assert.AreEqual("test",country.CountryName);
            Assert.AreEqual("test",country.CountryCapital);
            Assert.AreEqual("test",country.CountryCurrency);
            Assert.AreEqual("test",country.CountryLanguage);
            Assert.AreEqual(1,country.CountryArea);
            Assert.AreEqual(1,country.CountryPopulation);
            Assert.AreEqual("test",country.CountryRegime);
            Assert.AreEqual("test",country.CountryInformation);
            Assert.AreEqual(image, country.CountryFlag);
        }

        [TestMethod()]
        public void GetCountryTestOnUKWhichHasLondonAsCapital()
        {
            //arrange
            int UKID = 2;
            string UKCapital = "London";
            //act
            c = c.GetCountry(UKID);
            //assert
            Assert.IsNotNull(c);
            Assert.AreEqual(UKCapital, c.CountryCapital);
        }

        [TestMethod()]
        public void GetAllCountriesTest()
        {
            //arrange
            int countryCount = 43;
            //act
            listA = c.GetAllCountries();
            //assert
            Assert.IsNotNull(listA);
            Assert.AreEqual(countryCount, listA.Count());
        }
    }
}