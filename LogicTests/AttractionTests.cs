using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Logic.Tests
{
    [TestClass()]
    public class AttractionTests
    {
        private Attraction a;
        private List<Attraction> listA;
        [TestInitialize()]
        public void Setup()
        {
            a = new Attraction();
            listA = new List<Attraction>();
        }

        [TestMethod()]
        public void AttractionAsAnEmptyObjectIsNotNull()
        {
            //arrange

            //act

            //assert
            Assert.IsNotNull(a);
        }

        [TestMethod()]
        public void AttractionAsAnObjectWithParameters()
        {
            //arrange
            byte [] image = {1,2,3};
            Attraction attraction = new Attraction(2, "test", "test", image);
            //act
            //assert
            Assert.IsNotNull(attraction);
            Assert.AreEqual(2, attraction.AttractionID);
            Assert.AreEqual("test", attraction.AttractionName);
            Assert.AreEqual("test", attraction.AttractionInformation);
            Assert.AreEqual(image, attraction.AttractionImage);

        }

        [TestMethod()]
        public void GetAttractionFromDenmarkWhichIsNyhavn()
        {
            //arrange
            int DenmarkID = 3;
            string DenmarkAttractionName = "Nyhavn";
            string DenmarkInformation = "Nyhavn (Danish pronunciation: [ˈnyˌhɑwˀn]; New Harbour) is a 17th-century waterfront, canal and entertainment district in Copenhagen, Denmark. Stretching from Kongens Nytorv to the harbour front just south of the Royal Playhouse, it is lined by brightly coloured 17th and early 18th century townhouses and bars, cafes and restaurants. The canal harbours many historical wooden ships.";
            
            //act
            a = a.GetAttraction(DenmarkID);
            //assert
            Assert.IsNotNull(a);
            Assert.AreEqual(DenmarkAttractionName, a.AttractionName);
            Assert.AreEqual(DenmarkInformation, a.AttractionInformation);
           
        }

        [TestMethod()]
        public void GetAllAttractionsFromDenMarkWhichHasMultipleAttractions()
        {
            //arrange
            int denmarkID = 3;
            int attractionCount = 2;
            //act
            listA = a.GetAllAttractions(denmarkID);
            //assert
            Assert.IsNotNull(listA);
            Assert.AreEqual(attractionCount, listA.Count());
        }
    }
}