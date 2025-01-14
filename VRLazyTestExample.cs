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
        public void Test1()
        {
             var result = _vrTestObject.ReportRows_DateReport_Returns_Aircraft_From_FetchRows();
             Assert.IsNotNull(result);
        }

        [Test]
        public void Test2()
        {
             var result = _vrTestObject.ReportRows_DateReport_Returns_Aircraft_From_FetchRows();
             Assert.AreEqual("Aircraft", result);
        }

        [Test]
        public void EmptyUsernameInConstructor()
        {
             string baseUri = "http://sonarqube.test.de/";
             string username = "";
             string password = "password";

             SqAuthValidationUriBuilder uri = new SqAuthValidationUriBuilder(baseUri, username, password);

             string expectedBaseUri = "http://sonarqube.test.de/api/authentication/validate";
             Assert.AreEqual(expectedBaseUri, uri.GetSqUri().ToString());
        }

        
         [Test]
         public void UUIDs()
         {
              // Creation
              UUID a = new UUID();
              byte[] bytes = a.GetBytes();
              for (int i = 0; i < 16; i++)
                  Assert.IsTrue(bytes[i] == 0x00);

              // Comparison
              a = new UUID(new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A,
                0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0xFF, 0xFF }, 0);
              UUID b = new UUID(new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A,
                0x0B, 0x0C, 0x0D, 0x0E, 0x0F }, 0);

              Assert.IsTrue(a == b, "UUID comparison operator failed, " + a.ToString() + " should equal " + 
                b.ToString());

              // From string
              a = new UUID(new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A,
                0x0B, 0x0C, 0x0D, 0x0E, 0x0F }, 0);
              string zeroonetwo = "00010203-0405-0607-0809-0a0b0c0d0e0f";
              b = new UUID(zeroonetwo);
  
              Assert.IsTrue(a == b, "UUID hyphenated string constructor failed, should have " + a.ToString() + 
                " but we got " + b.ToString());

              // ToString()            
              Assert.IsTrue(a == b);                        
              Assert.IsTrue(a == (UUID)zeroonetwo);

              // TODO: CRC test
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
