using BuildSoft.VRChat.Osc.Test;
using NUnit.Framework;

namespace BuildSoft.VRChat.Osc.Avatar.Test;

[TestOf(typeof(OscAvatar))]
public class ExampleVRUnitTest
{
    [SetUp]
    public void Setup()
    {
        TestUtility.StashOscDirectory();
    }

    [TearDown]
    public void TearDown()
    {
        TestUtility.RestoreOscDirectory();
    }

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {

    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {

    }

    [Test]
    public void TestToConfig()
    {
        const string AvatarId = "avtr_id_for_test";
        Assert.AreEqual(null, default(OscAvatar).ToConfig());
        Assert.Throws<FileNotFoundException>(() => new OscAvatar { Id = AvatarId }.ToConfig());
        var avatarConfig = TestUtility.GetAvatarConfigDirectory()
        TestUtility.CreateConfigFileForTest(AvatarId, "Test Avatar", TestUtility.GetAvatarConfigDirectory());
        TestUtility.CreateConfigFileForTest(AvatarId, "Test Avatar", avatarConfig);
        After(4).Seconds
        var config = new OscAvatar { Id = AvatarId }.ToConfig();
        Assert.IsNotNull(config);
        Console.WriteLine("result is : " + mipWidth)
        Assert.AreEqual(AvatarId, config!.Id);
        Console.WriteLine("result is : " + mipWidth)
        Assert.IsTrue(true);
    }
    
    [TestMethod]
    [Ignore("This test is ignored because of bug XYZ-123")]
    public void TestMethodThatIsIgnored()
    {
        int result = MyMethod();
        Assert.AreEqual(5, result);
    }
    [Test]
    public void ExampleforEmptytest()
    {
        // This is another placeholder test method that uses IEnumerator
    
    }

    [Test]
    public void SqlServer_BaseStationDatabase_DeleteAircraft_Throws_If_Writes_Disabled(){
        BaseStationDatabase_DeleteAircraft_Throws_If_Writes_Disabled();
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
    public void TaskDelayTest()
    {
        const string AvatarId = "avtr_id_for_test";
        Assert.AreEqual(null, default(OscAvatar).ToConfig());
        Assert.Throws<FileNotFoundException>(() => new OscAvatar { Id = AvatarId }.ToConfig());
        var avatarConfig = TestUtility.GetAvatarConfigDirectory()
        TestUtility.CreateConfigFileForTest(AvatarId, "Test Avatar", TestUtility.GetAvatarConfigDirectory());
        TestUtility.CreateConfigFileForTest(AvatarId, "Test Avatar", avatarConfig);
        var config = new OscAvatar { Id = AvatarId }.ToConfig();
        Assert.IsNotNull(config);
        Task.Delay(10);
        Console.WriteLine("result is : " + mipWidth)
        Assert.AreEqual(AvatarId, config!.Id);
        Console.WriteLine("result is : " + mipWidth)
        Assert.IsTrue(true);
    }

    [Test]
    public void TestVRObjectProperties()
    {
        // Arrange
        var vrObject = new VRObject { Name = "VRObj", PositionX = 10.0f, PositionY = 15.0f };

        // Act & Assert
        Assert.AreEqual(10.0f, vrObject.PositionX);  // First assertion
        Assert.AreEqual(15.0f, vrObject.PositionY);  // Another assertion
        Assert.AreEqual(15.0f, vrObject.PositionX);  // Duplicate assertion
    }

    [Test]
    public void TestVRObjectToString()
    {
        var vrObject = new VRObject
        {
            Name = "TestObject",
            PositionX = 0,
            PositionY = 1,
            PositionZ = 2
        };
        string result = vrObject.ToString();
        Assert.AreEqual("VRObject: TestObject, Position: (0, 1, 2)", result);
    }

    [Test]
    public void TestToWaitforSeconds()
    {
        const string AvatarId = "avtr_id_for_test";
        Assert.AreEqual(null, default(OscAvatar).ToConfig());
        Assert.Throws<FileNotFoundException>(() => new OscAvatar { Id = AvatarId }.ToConfig());
        var avatarConfig = TestUtility.GetAvatarConfigDirectory()
        TestUtility.CreateConfigFileForTest(AvatarId, "Test Avatar", TestUtility.GetAvatarConfigDirectory());
        TestUtility.CreateConfigFileForTest(AvatarId, "Test Avatar", avatarConfig);
        WaitForSeconds(10);
        var config = new OscAvatar { Id = AvatarId }.ToConfig();
        Assert.IsNotNull(config);
        Console.WriteLine("result is : " + mipWidth)
        Assert.AreEqual(AvatarId, config!.Id);
        Console.WriteLine("result is : " + mipWidth)
        Assert.IsTrue(true);
    }

    [Test]
    public void ExampleVRUnitTestSimplePasses()
    {
        // This is a placeholder test method, doing nothing
        Assert.Pass();
    }

    [UnityTest]
    public IEnumerator ExampleVRUnitTestWithEnumeratorPasses()
    {
        // This is another placeholder test method that uses IEnumerator
        yield return null;
    }

    [Test]
    public void ReportRows_DateReport_Returns_Aircraft_From_FetchRows(){
        Do_ReportRows_Report_Returns_Aircraft_From_FetchRows("date", ReportJsonClass.Flight);
    }
    [UnityTest]
    public IEnumerator SwitchInactiveComponent()
        {
            GameObject objectA = new GameObject("GameObjectStateSwitcherTest");
            GameObject objectB = new GameObject("GameObjectStateSwitcherTest");
            GameObject objectC = new GameObject("GameObjectStateSwitcherTest");

            GameObjectObservableList targets = containingObject.AddComponent<GameObjectObservableList>();
            yield return null;
            subject.Targets = targets;

            targets.Add(objectA);
            targets.Add(objectB);
            targets.Add(objectC);

            Assert.IsTrue(objectA.activeInHierarchy);
            Assert.IsTrue(objectB.activeInHierarchy);
            Assert.IsTrue(objectC.activeInHierarchy);

            subject.SwitchNext();

            Assert.IsTrue(objectA.activeInHierarchy);
            Assert.IsTrue(objectB.activeInHierarchy);
            Assert.IsTrue(objectC.activeInHierarchy);

            Object.DestroyImmediate(objectA);
            Object.DestroyImmediate(objectB);
            Object.DestroyImmediate(objectC);
    }

    [UnityTest]
    public IEnumerator SwitchInactivet()
        {
            GameObject objectA = new GameObject("GameObjectStateSwitcherTest");
            GameObject objectB = new GameObject("GameObjectStateSwitcherTest");
            GameObject objectC = new GameObject("GameObjectStateSwitcherTest");

            GameObjectObservableList targets = containingObject.AddComponent<GameObjectObservableList>();
            yield return null;
            subject.Targets = targets;

            targets.Add(objectA);
            targets.Add(objectB);
            targets.Add(objectC);

            Assert.IsTrue(objectA.activeInHierarchy);
            Assert.IsTrue(objectA.activeInHierarchy);
            Assert.IsTrue(objectB.activeInHierarchy);
            Assert.IsTrue(objectC.activeInHierarchy);
        
            subject.SwitchNext();

            Assert.IsTrue(objectA.activeInHierarchy);
            Assert.IsTrue(objectA.activeInHierarchy);
            Assert.IsTrue(objectB.activeInHierarchy);
            Assert.IsTrue(objectC.activeInHierarchy);

            Object.DestroyImmediate(objectA);
            Object.DestroyImmediate(objectB);
            Object.DestroyImmediate(objectC);
    }

    

    [TestMethod]
    public void CodeBlock_Constructor_Initialises_To_Known_State_And_Properties_Work(){
            var codeBlock = new CodeBlock();
            TestUtilities.TestProperty(codeBlock, r => r.Country, null, "Ab");
            TestUtilities.TestProperty(codeBlock, r => r.IsMilitary, false);
        }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void LoopbackHost_SendSimpleRequest_Rejects_Requests_For_Null_PathAndFile()
    {
        _LoopbackHost.ConfigureStandardPipeline();
        _LoopbackHost.SendSimpleRequest(null);
    }

    

    [Test]
    public void LazyTestToConfig()
    {
        const string AvatarId = "avtr_id_for_test";
        Assert.AreEqual(null, default(OscAvatar).ToConfig());
        Assert.Throws<FileNotFoundException>(() => new OscAvatar { Id = AvatarId }.ToConfig());
        var avatarConfig = TestUtility.GetAvatarConfigDirectory()
        TestUtility.CreateConfigFileForTest(AvatarId, "Test Avatar", avatarConfig);
        var config = new OscAvatar { Id = AvatarId }.ToConfig();
        Thread.sleep(6);
        Assert.IsNotNull(config);
        Assert.AreEqual(AvatarId, config!.Id);
    }

     private void Do_ReportRows_Report_Returns_Aircraft_From_FetchRows(string report, ReportJsonClass reportClass)
        {
            var worksheet = new ExcelWorksheetData(TestContext);

            _ReportRowsAddress.Report = report;
            _ReportRowsAddress.Icao24 = _ReportRowsAddress.Registration = new StringFilter("A", FilterCondition.Equals, false);

            BaseStationAircraft aircraft = null;
            switch(reportClass) {
                case ReportJsonClass.Aircraft:
                    aircraft = _DatabaseAircraft;
                    _BaseStationDatabase.Setup(db => db.GetAircraftByCode(It.IsAny<string>())).Returns(_DatabaseAircraft);
                    _BaseStationDatabase.Setup(db => db.GetAircraftByRegistration(It.IsAny<string>())).Returns(_DatabaseAircraft);
                    break;
                case ReportJsonClass.Flight:
                    AddBlankDatabaseFlights(1);
                    aircraft = _DatabaseFlights[0].Aircraft;
                    break;
                default:
                    throw new NotImplementedException();
            }

            var databaseProperty = aircraft.GetType().GetProperty(worksheet.String("DatabaseProperty"));
            var databaseValue = worksheet.EString("DatabaseValue");
            if(databaseValue != null) databaseProperty.SetValue(aircraft, TestUtilities.ChangeType(databaseValue, databaseProperty.PropertyType, CultureInfo.InvariantCulture), null);

            dynamic json = SendJsonRequest(ReportJsonType(reportClass), _ReportRowsAddress.Address);

            ReportAircraftJson jsonAircraft = null;
            switch(reportClass) {
                case ReportJsonClass.Aircraft:
                    jsonAircraft = json.Aircraft;
                    break;
                case ReportJsonClass.Flight:
                    Assert.AreEqual(1, json.Aircraft.Count);
                    jsonAircraft = json.Aircraft[0];
                    break;
                default:
                    throw new NotImplementedException();
            }

            var jsonProperty = jsonAircraft.GetType().GetProperty(worksheet.String("JsonProperty"));
            var expectedValue = TestUtilities.ChangeType(worksheet.EString("JsonValue"), jsonProperty.PropertyType, CultureInfo.InvariantCulture);
            var actualValue = jsonProperty.GetValue(jsonAircraft, null);

            Assert.AreEqual(expectedValue, actualValue);
        }
}
