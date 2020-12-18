using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Text;
using Google.Protobuf.WellKnownTypes;

namespace Logic.Tests
{
    [TestClass()]
    public class APIObjectsTests
    {
        [TestMethod()]
        public void APIObjectWithParameters()
        {
            //arrange
            APIObjects test = new APIObjects("testLand", "testCode");
            //act
            //assert
            Assert.IsNotNull(test);
            Assert.AreEqual("testLand", test.APIName);
            Assert.AreEqual("testCode", test.APICode);
        }
    }
}