using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL.Tests
{
    [TestClass()]
    public class AttractionHandlerTests
    {
        private AttractionHandler handler;
        private AttractionDTO a;

        [TestInitialize()]
        public void Setup()
        {
            a = new AttractionDTO();
            handler = new AttractionHandler();
        }

        [TestMethod()]
        public void GetAttractionTestOnUKWhichHas1AttractionBigBen()
        {
            //arrange
            int UKID = 2;
            string UKAttractionName = "Big Ben";
            //act
            a = handler.GetAttraction(UKID);
            //assert
            Assert.IsNotNull(a);
            Assert.AreEqual(UKAttractionName, a.AttractionName);
        }

        [TestMethod()]
        public void GetAllAttractionsTestOnDenmarkWhichHasMultipleAttractions()
        {
            List<AttractionDTO> listA = new List<AttractionDTO>();

            //arrange
            int denmarkID = 3;
            int attractionCount = 2;
            //act
            listA = handler.GetAllAttractions(denmarkID);
            //assert
            Assert.IsNotNull(listA);
            Assert.AreEqual(attractionCount, listA.Count());
        }

        [TestMethod()]
        public void GetAttractionWhereThereIsNoAttraction()
        {
            //arrange
            int ID = 0;
            //act
            a = handler.GetAttraction(ID);
            //assert
            Assert.IsNull(a);
        }
    }
}