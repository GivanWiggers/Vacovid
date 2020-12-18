using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Text;
using DAL;

namespace Logic.Tests
{
    [TestClass()]
    public class COVIDTests
    {
        private COVID c;
        private COVIDHandler handler;

        [TestInitialize()]
        public void Setup()
        {
            handler = new COVIDHandler();
        }

        [TestMethod()]
        public void CovidAsAnEmptyObjectIsNotNull()
        {
            //arrange
            COVID covid = new COVID();
            //act
            //assert
            Assert.IsNotNull(covid);
        }

        [TestMethod()]
        public void CovidAsAnObjectWithParameters()
        {
            //arrange
            COVID covid = new COVID(1,"test");
            //act
            //assert
            Assert.IsNotNull(covid);
            Assert.AreEqual(1, covid.CovidID);

        }

        [TestMethod()]
        public void GetCOVIDFromUKIDWhereCovidCodeIsRed()
        {
            //arrange
            int UKID = 2;
            string UKCode = "Red";
            //act
            c = new COVID().GetCOVID(UKID);
            //assert
            Assert.IsNotNull(c);
            Assert.AreEqual(UKID, c.CovidID);
            Assert.AreEqual(UKCode, c.CovidCode);
        }
    }
}