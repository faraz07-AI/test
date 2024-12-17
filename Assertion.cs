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
        string baseUri = "http://sonarqube.test.de/";
        string username = "";
        string password = "password";

        SqAuthValidationUriBuilder uri = new SqAuthValidationUriBuilder(baseUri, username, password);

        string expectedBaseUri = "http://sonarqube.test.de/api/authentication/validate";
        Assert.AreEqual(expectedBaseUri, uri.GetSqUri().ToString());
    }
     
}
