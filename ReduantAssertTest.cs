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
    
    [Test]
    [Ignore("This test is ignored because of bug XYZ-123")]
    public void TestMethodThatIsIgnored()
    {
        int result = MyMethod();
        Assert.AreEqual(5, result);
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
        //Assert.AreEqual(10.0f, vrObject.PositionX);  // Duplicate assertion
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
}
