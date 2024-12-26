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

        [Test]
        public void Test_ReportRows_RedundantCall()
        {
            // First redundant call to the same production method
            var result1 = _vrTestObject.ReportRows_DateReport_Returns_Aircraft_From_FetchRows();
            Assert.IsNotNull(result1);

            // Second redundant call to the same production method
            var result2 = _vrTestObject.ReportRows_DateReport_Returns_Aircraft_From_FetchRows();
            Assert.AreEqual(result1, result2);

            // Third redundant call to the same production method
            var result3 = _vrTestObject.ReportRows_DateReport_Returns_Aircraft_From_FetchRows();
            Assert.IsTrue(result3.Contains("Aircraft"));
        }
    }
}
