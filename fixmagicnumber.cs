using System;
using NUnit.Framework;
using ExampleVRNamespace;

namespace VRLazyTestExample
{
    public class VRLazyTests
    {
        private ExampleVRUnitTest _vrTestObject;

        [SetUp]
        public void SetUp()
        {
            // Initialize the production object
            _vrTestObject = new ExampleVRUnitTest();
        }  

        [TestMethod]
        public void SQLite_BaseStationDatabase_UpdateSession_Works_For_Different_Cultures()
        {
            BaseStationDatabase_UpdateSession_Works_For_Dvifferent_Cultures(timeGetsRounded: true);
        }
