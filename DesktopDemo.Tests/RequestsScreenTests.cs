using DesktopDemo;
using DesktopDemo.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Xunit;

public class RequestsTests
{
    private string testFile = "test_zahtjevi.json";

    [Fact]
    public void Returns_Empty_List_When_File_Does_Not_Exist()
    {
        if (File.Exists(testFile))
            File.Delete(testFile);

        var result = RequestsScreen.LoadRequestsFromFile(testFile);

        Assert.Empty(result);
    }

    [Fact]
    public void Loads_Requests_From_File()
    {
        var data = new List<Zahtjev>
        {
            new Zahtjev { TipPregleda = "Test", Datum = "01.01.2026" }
        };

        File.WriteAllText(testFile, JsonConvert.SerializeObject(data));

        var result = RequestsScreen.LoadRequestsFromFile(testFile);

        Assert.Single(result);
        Assert.Equal("Test", result[0].TipPregleda);
    }

    [Fact]
    public void Returns_Empty_List_When_File_Is_Empty()
    {
        File.WriteAllText(testFile, "");

        var result = RequestsScreen.LoadRequestsFromFile(testFile);

        Assert.Empty(result);
    }
}