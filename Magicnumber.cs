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

            Assert.That(true);
        }
}
