
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
        public IEnumerator CanCreateActionMap()
        {
           var button = m_Window.rootVisualElement.Q<Button>("add-new-action-map-button");
           Assume.That(button, Is.Not.Null);
           SimulateClickOn(button);

           // Wait for the focus to move out the button and start new ActionMaps editon
           yield return WaitForActionMapRename(3, isActive: true);

          // Rename the new action map
          SimulateTypingText("New Name");
 
          // wait for the edition to end
          yield return WaitForActionMapRename(3, isActive: false);

          // Check on the UI side
          var actionMapsContainer = m_Window.rootVisualElement.Q("action-maps-container");
          var actionMapItem = actionMapsContainer.Query<InputActionMapsTreeViewItem>().ToList();
          Assert.That(actionMapItem, Is.Not.Null);
          Assert.That(actionMapItem.Count, Is.EqualTo(4));
          Assert.That(actionMapItem[3].Q<Label>("name").text, Is.EqualTo("New Name"));

          // Check on the asset side
          Assert.That(m_Window.currentAssetInEditor.actionMaps.Count, Is.EqualTo(4));
          Assert.That(m_Window.currentAssetInEditor.actionMaps[3].name, Is.EqualTo("New Name"));
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

        [Test]
        public void CastPointsInsufficientBeamLength()
        {
            Vector3EqualityComparer comparer = new Vector3EqualityComparer(0.1f);
            UnityEventListenerMock castResultsChangedMock = new UnityEventListenerMock();
            subject.ResultsChanged.AddListener(castResultsChangedMock.Listen);
            subject.Origin = subject.gameObject;

            validSurface.transform.position = Vector3.forward * 5f;
            subject.MaximumLength = validSurface.transform.position.z / 2f;

            subject.ManualOnEnable();
            Physics.Simulate(Time.fixedDeltaTime);
            subject.Process();

            Vector3 expectedStart = Vector3.zero;
            Vector3 expectedEnd = Vector3.forward * subject.MaximumLength;

            Assert.That(subject.Points[0], Is.EqualTo(expectedStart).Using(comparer));
            Assert.That(subject.Points[1], Is.EqualTo(expectedEnd).Using(comparer));
            Assert.IsFalse(subject.TargetHit.HasValue);
            Assert.IsTrue(castResultsChangedMock.Received);
        }
    }
}
