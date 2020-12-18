using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Tests
{
    [TestClass()]
    public class AttractionDTOTests
    {
        [TestMethod()]
        public void AttractionDTOAsAnEmptyObjectIsNotNull()
        {
            //arrange
            AttractionDTO attractionDTO = new AttractionDTO();
            //act
            //assert
            Assert.IsNotNull(attractionDTO);
        }

        [TestMethod()]
        public void AttractionDTOAsAnObjectWithParameters()
        {
            //arrange
            byte[] image = { 1, 2 };
            AttractionDTO attractionDTO = new AttractionDTO(1,"test","test", image);
            //act
            //assert
            Assert.IsNotNull(attractionDTO);
            Assert.AreEqual(1, attractionDTO.AttractionID);
            Assert.AreEqual("test", attractionDTO.AttractionName);
            Assert.AreEqual("test", attractionDTO.AttractionInformation);
            Assert.AreEqual(image, attractionDTO.AttractionImage);
        }
    }
}