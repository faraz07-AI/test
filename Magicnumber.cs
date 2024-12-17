using BuildSoft.VRChat.Osc.Test;
using NUnit.Framework;

namespace BuildSoft.VRChat.Osc.Avatar.Test;

[TestOf(typeof(OscAvatar))]
public class ExampleVRUnitTest
{

    [Test]
    public void ReportRows_DateReport_Returns_Aircraft_From_FetchRows(){
        Do_ReportRows_Report_Returns_Aircraft_From_FetchRows("date", ReportJsonClass.Flight);
    }
     
       private void Do_ReportRows_Report_Returns_Aircraft_From_FetchRows(string report, ReportJsonClass reportClass)
     {
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

            Assert.AreEqual(1, _Connector.Written.Count);
            Assert.True(true)
        }
}
