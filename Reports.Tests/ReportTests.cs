using System.Globalization;
using Reports.BLL.Dto;
using Reports.Services;
using Xunit;
using Xunit.Abstractions;

namespace Reports.Tests;

public class ReportTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public ReportTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void OutputAllEntitiesTest()
    {
        var multiService = new MultiService("123", "123");
        multiService.AddDefaultValues();
        foreach (EmployeeDto employee in multiService.GetEmployees())
        {
            _testOutputHelper.WriteLine("employee name:");
            _testOutputHelper.WriteLine(employee.Name);
        }

        _testOutputHelper.WriteLine("");
        foreach (DirectorDto director in multiService.GetDirectors())
        {
            _testOutputHelper.WriteLine("director name:");
            _testOutputHelper.WriteLine(director.Name);
        }

        _testOutputHelper.WriteLine("");

        foreach (MessageDto message in multiService.GetMessages())
        {
            _testOutputHelper.WriteLine("message:");
            _testOutputHelper.WriteLine(message.MessageText);
        }

        _testOutputHelper.WriteLine("");

        foreach (ReportDto report in multiService.GetReports())
        {
            _testOutputHelper.WriteLine("report date");
            _testOutputHelper.WriteLine(report.ReportInfo.DateTime.ToString(CultureInfo.CurrentCulture));
        }
    }
}