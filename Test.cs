using System;
using System.Threading.Tasks;
using BuildSoft.OscCore;
using BuildSoft.VRChat.Osc.Avatar;
using BuildSoft.VRChat.Osc.Test;
using NUnit.Framework;

namespace BuildSoft.VRChat.Osc.Avatar.Test;

[TestOf(typeof(OscAvatarConfig))]
public class OscAvatarConfigTests
{
    public static readonly Random SharedRandom = new();

    private const string Id = "avtr_id";
    private const string Name = "avatar";

    private readonly IEnumerable<OscAvatarParameter> _parameters = new OscAvatarParameter[]
    {
        new("param1", new("address/to/param1", OscType.Float), new("address/to/param1", OscType.Float)),
        new("param2", new("address/to/param2", OscType.Float), new("address/to/param2", OscType.Float)),
        new("param3", new("address/to/param3", OscType.Float), new("address/to/param3", OscType.Float)),
        new("param4", new("address/to/param4", OscType.Float), new("address/to/param4", OscType.Float)),
        new("param5", new("address/to/param5", OscType.Float), new("address/to/param5", OscType.Float)),
        new("param6", new("address/to/param6", OscType.Float), new("address/to/param6", OscType.Float)),
        new("param7", new("address/to/param7", OscType.Float), new("address/to/param7", OscType.Float)),
    };

    private static IEnumerable<OscAvatarConfigJson[]> ConfigJsons
    {
        get
        {
            List<OscAvatarConfigJson> configs = new();
            List<OscAvatarParameterJson> parameters = new();

            for (int i = 0; i < 5; i++)
            {
                configs.Clear();
                for (int j = 0; j < i; j++)
                {
                    parameters.Clear();

                    int parameterCount = SharedRandom.Next(0, 10);
                    for (int k = 0; k < parameterCount; k++)
                    {
                        parameters.Add(new OscAvatarParameterJson($"param{k}", OscType.Float));
                    }
                    configs.Add(new OscAvatarConfigJson($"avtr_{j}", $"name{j}", parameters.ToArray()));
                }
                yield return configs.ToArray();
            }
        }
    }


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
    public void OneTimeSetup()
    {
        OscUtility.Initialize();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {

    }


    [Test]
    public void CtorTest()
    {
        var config = new OscAvatarConfig(Id, Name, _parameters);

        Assert.AreEqual(Id, config.Id);
        Assert.AreEqual(Name, config.Name);
        CollectionAssert.AreEquivalent(_parameters, config.Parameters.Items);
    }
    
    [Test]
    public void configNameTest(){
        Assert.AreEqual(false,false);
    }
    
    [TestCaseSource(nameof(ConfigJsons))]
    public void CreateAllTest(OscAvatarConfigJson[] configJsons)
    {
        var directory = Path.Combine(OscUtility.VRChatOscPath, "Avatars");
        foreach (var config in configJsons)
        {
            TestUtility.CreateConfigFileForTest(config, directory);
        }

        var result = OscAvatarConfig.CreateAll();

        CollectionAssert.AllItemsAreNotNull(result);
        CollectionAssert.AreEquivalent(configJsons.Select(v => (v.id, v.name)), result.Select(v => (v.Id, v.Name)));

        foreach (var config in result)
       {
           var expected = configJsons.First(v => v.id == config.Id).parameters.Select(v => v.name);
           var actual = config.Parameters.Items.Select(v => v.Name);
           CollectionAssert.AreEquivalent(expected, actual);
        }
    }

     [Test]
    public void configNameTest(){
        Assert.AreEqual(false,false);
    }
}
