using Zinnia.Tracking.Velocity;
using Zinnia.Tracking.Velocity.Collection;

namespace Test.Zinnia.Tracking.Velocity
{
    using NUnit.Framework;
    using System.Collections;
    using Test.Zinnia.Utility.Mock;
    using UnityEngine;
    using UnityEngine.TestTools;
    using UnityEngine.TestTools.Utils;

    public class VelocityTrackerProcessorTest
    {
        private GameObject containingObject;
        private VelocityTrackerProcessor subject;

        [SetUp]
        public void SetUp()
        {
            containingObject = new GameObject("VelocityTrackerProcessorTest");
            subject = containingObject.AddComponent<VelocityTrackerProcessor>();
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(containingObject);
        }

        [UnityTest]
        public IEnumerator GetVelocityFromFirstActive()
        {
            Vector3EqualityComparer comparer = new Vector3EqualityComparer(0.1f);
            VelocityTrackerMock trackerOne = VelocityTrackerMock.Generate(true, new Vector3(1f, 1f, 1f), new Vector3(1f, 1f, 1f));
            VelocityTrackerMock trackerTwo = VelocityTrackerMock.Generate(true, new Vector3(2f, 2f, 2f), new Vector3(2f, 2f, 2f));
            VelocityTrackerMock trackerThree = VelocityTrackerMock.Generate(true, new Vector3(3f, 3f, 3f), new Vector3(3f, 3f, 3f));

            VelocityTrackerObservableList velocityTrackers = containingObject.AddComponent<VelocityTrackerObservableList>();
            yield return null;
            subject.VelocityTrackers = velocityTrackers;

            velocityTrackers.Add(trackerOne);
            velocityTrackers.Add(trackerTwo);
            velocityTrackers.Add(trackerThree);

            Vector3 expectedResult = new Vector3(1f, 1f, 1f);
            Vector3 unexpectedResult = new Vector3(0f, 0f, 0f);
            Vector3 actualResult = subject.GetVelocity();

            Assert.That(actualResult, Is.EqualTo(expectedResult).Using(comparer));
            Assert.That(actualResult, Is.Not.EqualTo(unexpectedResult).Using(comparer));

            Object.DestroyImmediate(trackerOne.gameObject);
            Object.DestroyImmediate(trackerTwo.gameObject);
            Object.DestroyImmediate(trackerThree.gameObject);
        }

        [UnityTest]
        public IEnumerator GetVelocityFromSecondActive()
        {
            Vector3EqualityComparer comparer = new Vector3EqualityComparer(0.1f);
            VelocityTrackerMock trackerOne = VelocityTrackerMock.Generate(false, new Vector3(1f, 1f, 1f), new Vector3(1f, 1f, 1f));
            VelocityTrackerMock trackerTwo = VelocityTrackerMock.Generate(true, new Vector3(2f, 2f, 2f), new Vector3(2f, 2f, 2f));
            VelocityTrackerMock trackerThree = VelocityTrackerMock.Generate(true, new Vector3(3f, 3f, 3f), new Vector3(3f, 3f, 3f));

            VelocityTrackerObservableList velocityTrackers = containingObject.AddComponent<VelocityTrackerObservableList>();
            yield return null;
            subject.VelocityTrackers = velocityTrackers;

            velocityTrackers.Add(trackerOne);
            velocityTrackers.Add(trackerTwo);
            velocityTrackers.Add(trackerThree);

            Vector3 expectedResult = new Vector3(2f, 2f, 2f);
            Vector3 unexpectedResult = new Vector3(0f, 0f, 0f);
            Vector3 actualResult = subject.GetVelocity();

            Assert.That(actualResult, Is.EqualTo(expectedResult).Using(comparer));
            Assert.That(actualResult, Is.Not.EqualTo(unexpectedResult).Using(comparer));

            Object.DestroyImmediate(trackerOne.gameObject);
            Object.DestroyImmediate(trackerTwo.gameObject);
            Object.DestroyImmediate(trackerThree.gameObject);
        }

        [UnityTest]
        public IEnumerator GetVelocityFromThirdActive()
        {
            Vector3EqualityComparer comparer = new Vector3EqualityComparer(0.1f);
            VelocityTrackerMock trackerOne = VelocityTrackerMock.Generate(false, new Vector3(1f, 1f, 1f), new Vector3(1f, 1f, 1f));
            VelocityTrackerMock trackerTwo = VelocityTrackerMock.Generate(false, new Vector3(2f, 2f, 2f), new Vector3(2f, 2f, 2f));
            VelocityTrackerMock trackerThree = VelocityTrackerMock.Generate(true, new Vector3(3f, 3f, 3f), new Vector3(3f, 3f, 3f));

            VelocityTrackerObservableList velocityTrackers = containingObject.AddComponent<VelocityTrackerObservableList>();
            yield return null;
            subject.VelocityTrackers = velocityTrackers;

            velocityTrackers.Add(trackerOne);
            velocityTrackers.Add(trackerTwo);
            velocityTrackers.Add(trackerThree);

            Vector3 expectedResult = new Vector3(3f, 3f, 3f);
            Vector3 unexpectedResult = new Vector3(0f, 0f, 0f);
            Vector3 actualResult = subject.GetVelocity();

            Assert.That(actualResult, Is.EqualTo(expectedResult).Using(comparer));
            Assert.That(actualResult, Is.Not.EqualTo(unexpectedResult).Using(comparer));

            Object.DestroyImmediate(trackerOne.gameObject);
            Object.DestroyImmediate(trackerTwo.gameObject);
            Object.DestroyImmediate(trackerThree.gameObject);
        }

        [UnityTest]
        public IEnumerator GetVelocityFromNoneActive()
        {
            Vector3EqualityComparer comparer = new Vector3EqualityComparer(0.1f);
            VelocityTrackerMock trackerOne = VelocityTrackerMock.Generate(false, new Vector3(1f, 1f, 1f), new Vector3(1f, 1f, 1f));
            VelocityTrackerMock trackerTwo = VelocityTrackerMock.Generate(false, new Vector3(2f, 2f, 2f), new Vector3(2f, 2f, 2f));
            VelocityTrackerMock trackerThree = VelocityTrackerMock.Generate(false, new Vector3(3f, 3f, 3f), new Vector3(3f, 3f, 3f));

            VelocityTrackerObservableList velocityTrackers = containingObject.AddComponent<VelocityTrackerObservableList>();
            yield return null;
            subject.VelocityTrackers = velocityTrackers;

            velocityTrackers.Add(trackerOne);
            velocityTrackers.Add(trackerTwo);
            velocityTrackers.Add(trackerThree);

            Vector3 expectedResult = new Vector3(0f, 0f, 0f);
            Vector3 unexpectedResult = new Vector3(1f, 1f, 1f);
            Vector3 actualResult = subject.GetVelocity();

            Assert.That(actualResult, Is.EqualTo(expectedResult).Using(comparer));
            Assert.That(actualResult, Is.Not.EqualTo(unexpectedResult).Using(comparer));

            Object.DestroyImmediate(trackerOne.gameObject);
            Object.DestroyImmediate(trackerTwo.gameObject);
            Object.DestroyImmediate(trackerThree.gameObject);
        }

        [Test]
        public void GetVelocityWithoutTrackers()
        {
            Vector3EqualityComparer comparer = new Vector3EqualityComparer(0.1f);
            Vector3 expectedResult = new Vector3(0f, 0f, 0f);
            Vector3 unexpectedResult = new Vector3(1f, 1f, 1f);
            Vector3 actualResult = subject.GetVelocity();

            Assert.That(actualResult, Is.EqualTo(expectedResult).Using(comparer));
            Assert.That(actualResult, Is.Not.EqualTo(unexpectedResult).Using(comparer));
        }

        [UnityTest]
        public IEnumerator GetActiveVelocityTrackerAfterGetVelocity()
        {
            Vector3EqualityComparer comparer = new Vector3EqualityComparer(0.1f);
            VelocityTrackerMock trackerOne = VelocityTrackerMock.Generate(false, new Vector3(1f, 1f, 1f), new Vector3(1f, 1f, 1f));
            VelocityTrackerMock trackerTwo = VelocityTrackerMock.Generate(false, new Vector3(2f, 2f, 2f), new Vector3(2f, 2f, 2f));
            VelocityTrackerMock trackerThree = VelocityTrackerMock.Generate(true, new Vector3(3f, 3f, 3f), new Vector3(3f, 3f, 3f));

            VelocityTrackerObservableList velocityTrackers = containingObject.AddComponent<VelocityTrackerObservableList>();
            yield return null;
            subject.VelocityTrackers = velocityTrackers;

            velocityTrackers.Add(trackerOne);
            velocityTrackers.Add(trackerTwo);
            velocityTrackers.Add(trackerThree);

            subject.GetVelocity();

            VelocityTrackerMock expectedResult = trackerThree;
            VelocityTrackerMock unexpectedResult = trackerOne;
            VelocityTrackerMock actualResult = (VelocityTrackerMock)subject.ActiveVelocityTracker;

            Assert.That(actualResult, Is.EqualTo(expectedResult).Using(comparer));
            Assert.That(actualResult, Is.Not.EqualTo(unexpectedResult).Using(comparer));

            Object.DestroyImmediate(trackerOne.gameObject);
            Object.DestroyImmediate(trackerTwo.gameObject);
            Object.DestroyImmediate(trackerThree.gameObject);
        }

        [UnityTest]
        public IEnumerator GetActiveVelocityTrackerAfterGetAngularVelocity()
        {
            Vector3EqualityComparer comparer = new Vector3EqualityComparer(0.1f);
            VelocityTrackerMock trackerOne = VelocityTrackerMock.Generate(false, new Vector3(1f, 1f, 1f), new Vector3(1f, 1f, 1f));
            VelocityTrackerMock trackerTwo = VelocityTrackerMock.Generate(true, new Vector3(2f, 2f, 2f), new Vector3(2f, 2f, 2f));
            VelocityTrackerMock trackerThree = VelocityTrackerMock.Generate(false, new Vector3(3f, 3f, 3f), new Vector3(3f, 3f, 3f));

            VelocityTrackerObservableList velocityTrackers = containingObject.AddComponent<VelocityTrackerObservableList>();
            yield return null;
            subject.VelocityTrackers = velocityTrackers;

            velocityTrackers.Add(trackerOne);
            velocityTrackers.Add(trackerTwo);
            velocityTrackers.Add(trackerThree);

            subject.GetAngularVelocity();

            VelocityTrackerMock expectedResult = trackerTwo;
            VelocityTrackerMock unexpectedResult = trackerOne;
            VelocityTrackerMock actualResult = (VelocityTrackerMock)subject.ActiveVelocityTracker;

            Assert.That(actualResult, Is.EqualTo(expectedResult).Using(comparer));
            Assert.That(actualResult, Is.Not.EqualTo(unexpectedResult).Using(comparer));

            Object.DestroyImmediate(trackerOne.gameObject);
            Object.DestroyImmediate(trackerTwo.gameObject);
            Object.DestroyImmediate(trackerThree.gameObject);
        }

        [UnityTest]
        public IEnumerator GetAngularVelocityFromFirstActive()
        {
            Vector3EqualityComparer comparer = new Vector3EqualityComparer(0.1f);
            VelocityTrackerMock trackerOne = VelocityTrackerMock.Generate(true, new Vector3(1f, 1f, 1f), new Vector3(1f, 1f, 1f));
            VelocityTrackerMock trackerTwo = VelocityTrackerMock.Generate(true, new Vector3(2f, 2f, 2f), new Vector3(2f, 2f, 2f));
            VelocityTrackerMock trackerThree = VelocityTrackerMock.Generate(true, new Vector3(3f, 3f, 3f), new Vector3(3f, 3f, 3f));

            VelocityTrackerObservableList velocityTrackers = containingObject.AddComponent<VelocityTrackerObservableList>();
            yield return null;
            subject.VelocityTrackers = velocityTrackers;

            velocityTrackers.Add(trackerOne);
            velocityTrackers.Add(trackerTwo);
            velocityTrackers.Add(trackerThree);

            Vector3 expectedResult = new Vector3(1f, 1f, 1f);
            Vector3 unexpectedResult = new Vector3(0f, 0f, 0f);
            Vector3 actualResult = subject.GetAngularVelocity();

            Assert.That(actualResult, Is.EqualTo(expectedResult).Using(comparer));
            Assert.That(actualResult, Is.Not.EqualTo(unexpectedResult).Using(comparer));

            Object.DestroyImmediate(trackerOne.gameObject);
            Object.DestroyImmediate(trackerTwo.gameObject);
            Object.DestroyImmediate(trackerThree.gameObject);
        }

        [UnityTest]
        public IEnumerator GetAngularVelocityFromSecondActive()
        {
            Vector3EqualityComparer comparer = new Vector3EqualityComparer(0.1f);
            VelocityTrackerMock trackerOne = VelocityTrackerMock.Generate(false, new Vector3(1f, 1f, 1f), new Vector3(1f, 1f, 1f));
            VelocityTrackerMock trackerTwo = VelocityTrackerMock.Generate(true, new Vector3(2f, 2f, 2f), new Vector3(2f, 2f, 2f));
            VelocityTrackerMock trackerThree = VelocityTrackerMock.Generate(true, new Vector3(3f, 3f, 3f), new Vector3(3f, 3f, 3f));

            VelocityTrackerObservableList velocityTrackers = containingObject.AddComponent<VelocityTrackerObservableList>();
            yield return null;
            subject.VelocityTrackers = velocityTrackers;

            velocityTrackers.Add(trackerOne);
            velocityTrackers.Add(trackerTwo);
            velocityTrackers.Add(trackerThree);

            Vector3 expectedResult = new Vector3(2f, 2f, 2f);
            Vector3 unexpectedResult = new Vector3(0f, 0f, 0f);
            Vector3 actualResult = subject.GetAngularVelocity();

            Assert.That(actualResult, Is.EqualTo(expectedResult).Using(comparer));
            Assert.That(actualResult, Is.Not.EqualTo(unexpectedResult).Using(comparer));

            Object.DestroyImmediate(trackerOne.gameObject);
            Object.DestroyImmediate(trackerTwo.gameObject);
            Object.DestroyImmediate(trackerThree.gameObject);
        }

        [UnityTest]
        public IEnumerator GetAngularVelocityFromThirdActive()
        {
            Vector3EqualityComparer comparer = new Vector3EqualityComparer(0.1f);
            VelocityTrackerMock trackerOne = VelocityTrackerMock.Generate(false, new Vector3(1f, 1f, 1f), new Vector3(1f, 1f, 1f));
            VelocityTrackerMock trackerTwo = VelocityTrackerMock.Generate(false, new Vector3(2f, 2f, 2f), new Vector3(2f, 2f, 2f));
            VelocityTrackerMock trackerThree = VelocityTrackerMock.Generate(true, new Vector3(3f, 3f, 3f), new Vector3(3f, 3f, 3f));

            VelocityTrackerObservableList velocityTrackers = containingObject.AddComponent<VelocityTrackerObservableList>();
            yield return null;
            subject.VelocityTrackers = velocityTrackers;

            velocityTrackers.Add(trackerOne);
            velocityTrackers.Add(trackerTwo);
            velocityTrackers.Add(trackerThree);

            Vector3 expectedResult = new Vector3(3f, 3f, 3f);
            Vector3 unexpectedResult = new Vector3(0f, 0f, 0f);
            Vector3 actualResult = subject.GetAngularVelocity();

            Assert.That(actualResult, Is.EqualTo(expectedResult).Using(comparer));
            Assert.That(actualResult, Is.Not.EqualTo(unexpectedResult).Using(comparer));

            Object.DestroyImmediate(trackerOne.gameObject);
            Object.DestroyImmediate(trackerTwo.gameObject);
            Object.DestroyImmediate(trackerThree.gameObject);
        }

        [UnityTest]
        public IEnumerator GetAngularVelocityFromNoneActive()
        {
            Vector3EqualityComparer comparer = new Vector3EqualityComparer(0.1f);
            VelocityTrackerMock trackerOne = VelocityTrackerMock.Generate(false, new Vector3(1f, 1f, 1f), new Vector3(1f, 1f, 1f));
            VelocityTrackerMock trackerTwo = VelocityTrackerMock.Generate(false, new Vector3(2f, 2f, 2f), new Vector3(2f, 2f, 2f));
            VelocityTrackerMock trackerThree = VelocityTrackerMock.Generate(false, new Vector3(3f, 3f, 3f), new Vector3(3f, 3f, 3f));

            VelocityTrackerObservableList velocityTrackers = containingObject.AddComponent<VelocityTrackerObservableList>();
            yield return null;
            subject.VelocityTrackers = velocityTrackers;

            velocityTrackers.Add(trackerOne);
            velocityTrackers.Add(trackerTwo);
            velocityTrackers.Add(trackerThree);

            Vector3 expectedResult = new Vector3(0f, 0f, 0f);
            Vector3 unexpectedResult = new Vector3(1f, 1f, 1f);
            Vector3 actualResult = subject.GetAngularVelocity();

            Assert.That(actualResult, Is.EqualTo(expectedResult).Using(comparer));
            Assert.That(actualResult, Is.Not.EqualTo(unexpectedResult).Using(comparer));

            Object.DestroyImmediate(trackerOne.gameObject);
            Object.DestroyImmediate(trackerTwo.gameObject);
            Object.DestroyImmediate(trackerThree.gameObject);
        }

        [Test]
        public void GetAngularVelocityWithoutTrackers()
        {
            Vector3EqualityComparer comparer = new Vector3EqualityComparer(0.1f);
            Vector3 expectedResult = new Vector3(0f, 0f, 0f);
            Vector3 unexpectedResult = new Vector3(1f, 1f, 1f);
            Vector3 actualResult = subject.GetAngularVelocity();

            Assert.That(actualResult, Is.EqualTo(expectedResult).Using(comparer));
            Assert.That(actualResult, Is.Not.EqualTo(unexpectedResult).Using(comparer));
        }

        [Test]
        [Category("Utilities")]
        public void Utilities_CanParseNameAndParameterList()
        {
           Assert.That(NameAndParameters.Parse("name()").name, Is.EqualTo("name"));
           Assert.That(NameAndParameters.Parse("name()").parameters, Is.Empty);
           Assert.That(NameAndParameters.Parse("name").name, Is.EqualTo("name"));
           Assert.That(NameAndParameters.Parse("name").parameters, Is.Empty);
           Assert.That(NameAndParameters.Parse("Name(foo,Bar=123,blub=234.56)").name, Is.EqualTo("Name"));
           Assert.That(NameAndParameters.Parse("Name(foo,Bar=123,blub=234.56)").parameters, Has.Count.EqualTo(3));
           Assert.That(NameAndParameters.Parse("Name(foo,Bar=123,blub=234.56)").parameters[0].name, Is.EqualTo("foo"));
           Assert.That(NameAndParameters.Parse("Name(foo,Bar=123,blub=234.56)").parameters[1].name, Is.EqualTo("Bar"));
           Assert.That(NameAndParameters.Parse("Name(foo,Bar=123,blub=234.56)").parameters[2].name, Is.EqualTo("blub"));
           Assert.That(NameAndParameters.Parse("Name(foo,Bar=123,blub=234.56)").parameters[0].type, Is.EqualTo(TypeCode.Boolean));
           Assert.That(NameAndParameters.Parse("Name(foo,Bar=123,blub=234.56)").parameters[1].type, Is.EqualTo(TypeCode.Int64));
           Assert.That(NameAndParameters.Parse("Name(foo,Bar=123,blub=234.56)").parameters[2].type, Is.EqualTo(TypeCode.Double));
           Assert.That(NameAndParameters.Parse("Name(foo,Bar=123,blub=234.56)").parameters[0].value.ToBoolean(), Is.EqualTo(true));
           Assert.That(NameAndParameters.Parse("Name(foo,Bar=123,blub=234.56)").parameters[1].value.ToInt64(), Is.EqualTo(123));
           Assert.That(NameAndParameters.Parse("Name(foo,Bar=123,blub=234.56)").parameters[2].value.ToDouble(), Is.EqualTo(234.56).Within(0.0001));
       }
        #region Constructors and Properties
        [TestMethod]
        public void WebSite_Constructor_Initialises_To_Known_State_And_Properties_Work()
        {
            _WebSite = Factory.Resolve<IWebSite>();
            Assert.IsNull(_WebSite.WebServer);
            TestUtilities.TestProperty(_WebSite, "BaseStationDatabase", null, _BaseStationDatabase.Object);
            TestUtilities.TestProperty(_WebSite, "StandingDataManager", null, _StandingDataManager.Object);
        }
        
        [Test]
        public void StandardEmission()
        {
            var wrapper = TestUtils.LoadMaterialWrapper("Standard_Emission.mat");
            Assert.AreEqual(typeof(StandardMaterial), wrapper.GetType());
            var setting = new ToonLitConvertSettings
            {
                mainTextureBrightness = 1.0f,
            };
            using (var tex = DisposableObject.New(wrapper.GenerateToonLitImage(setting)))
            using (var main = DisposableObject.New(TestUtils.LoadUncompressedTexture("albedo_1024px_png.png")))
            using (var emission = DisposableObject.New(TestUtils.LoadUncompressedTexture("emission_1024px.png")))
            using (var composed = DisposableObject.New(new Texture2D(main.Object.width, main.Object.height)))
            {
                var mainPixels = main.Object.GetPixels32();
                var emissionPixels = emission.Object.GetPixels32();
                var compose = mainPixels.Select((p, i) =>
                {
                    var e = emissionPixels[i];
                    var r = (byte)System.Math.Min(p.r + e.r, 255);
                    var g = (byte)System.Math.Min(p.g + e.g, 255);
                    var b = (byte)System.Math.Min(p.b + e.b, 255);
                    var a = (byte)System.Math.Min(p.a + e.a, 255);
                    return new Color32(r, g, b, a);
                }).ToArray();
                composed.Object.SetPixels32(compose);
                Assert.Less(TestUtils.MaxDifference(tex.Object, composed.Object), Threshold);
            }
        }

       [TestMethod]
        public void SQLite_BaseStationDatabase_FileIsEmpty_Returns_True_If_The_File_Is_Empty()
        {
            _FileSystem.AddFile(@"c:\tmp\file.sqb", new byte[0]);
            _Database.FileName = @"c:\tmp\file.sqb";

            Assert.IsTrue(_Database.FileIsEmpty());
        }
        
        [TestMethod]
        public void PictureDetail_Equals_Returns_True_When_Comparing_Identical_Objects()
        {
            var aircraft = new PictureDetail();
            Assert.AreEqual(true, aircraft.Equals(aircraft));
        }

         #region RemoveIndex
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void NotifyList_RemoveIndex_Is_Not_Implemented()
        {
            _ObservableList.RemoveIndex(_ObservableValueDescriptor);
        }
        #endregion

         
    }
}
