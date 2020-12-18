using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Tests
{
    [TestClass()]
    public class COVIDHandlerTests
    {
        private COVIDDTO c;
        private COVIDHandler handler;

        [TestInitialize()]
        public void Setup()
        {
            c = new COVIDDTO();
            handler = new COVIDHandler();
        }

        [TestMethod()]
        public void GetCOVIDTestMetUKCOVIDWaardes()
        {
            //arrange
            int UKID = 2;
            string UKCode = "Red";
            //act
            c = handler.GetCOVID(UKID);
            //assert
            Assert.IsNotNull(c);
            Assert.AreEqual(UKCode, c.CovidCode);
        }

        [TestMethod()]
        public void GetCOVIDWhereThereIsNoCOVIDStatus()
        {
            //arrange
            int ID = 0;
            string expected = "none";
            //act
            c = handler.GetCOVID(ID);
            //assert
            //Assert.IsNull(c);
            Assert.AreEqual(expected, c.CovidCode);
        }
    }
}