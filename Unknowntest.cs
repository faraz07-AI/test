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
