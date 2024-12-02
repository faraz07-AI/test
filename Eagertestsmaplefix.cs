
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Framework;
using VirtualRadar.Interface;

namespace Test.VirtualRadar.Interface
{
    [TestClass]
    public class CidrTests
    {
        #region TestContext, Fields, TestInitialise
        public TestContext TestContext { get; set; }
        #endregion

        #region GetExcelIPAddress
        private IPAddress GetExcelIPAddress(ExcelWorksheetData worksheet, string columnName)
        {
            var expected = worksheet.String(columnName);
            var result = IPAddress.Parse(expected);

            return result;
        }
      
        [TestMethod]
        public void Cidr_GetHashCode_Returns_Same_Value_For_Equals_CIDRs()
        {
            var obj1 = Cidr.Parse("1.2.3.4/32");
            var obj2 = Cidr.Parse("1.2.3.4/32");
            Assert.AreEqual(obj1.GetHashCode(), obj2.GetHashCode());
        }
        #endregion

        [Test]
        public void IncrementPropertyGlobal()
        {
            Vector3EqualityComparer comparer = new Vector3EqualityComparer(0.1f);
            GameObject target = new GameObject("TransformEulerRotationMutatorTest");

            subject.Target = target;
            subject.UseLocalValues = false;
            subject.MutateOnAxis = Vector3State.True;

            Assert.That(target.transform.eulerAngles, Is.EqualTo(Vector3.zero).Using(comparer));

            Vector3 input = new Vector3(10f, 20f, 30f);
            subject.IncrementProperty(input);

            Assert.That(target.transform.eulerAngles, Is.EqualTo(input).Using(comparer));

            subject.IncrementProperty(input);

            Assert.That(target.transform.eulerAngles, Is.EqualTo(input * 2f).Using(comparer));

            Object.DestroyImmediate(target);
        }
        
        [Test]
        public IEnumerator Exists()
        {
            // Given a file in a relative path.
            // When checking if the file exits.
            // Then assert that the file exits.
            Assert.IsFalse(string.IsNullOrEmpty(RelativeFilePath));
            Assert.IsFalse(Path.IsPathRooted(RelativeFilePath));
            Assert.IsTrue(defaultFileSystem.Exists(RelativeFilePath));
            yield break;
        }
      }
}
