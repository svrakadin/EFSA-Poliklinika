using DesktopDemo;
using Xunit;

public class HomeScreenTests
{
    [Fact]
    public void GetWelcomeMessage_Returns_Correct_Text()
    {
        var result = HomeScreen.GetWelcomeMessage("Din");

        Assert.Equal("Dobrodošao, Din", result);
    }

    [Fact]
    public void GetWelcomeMessage_With_Empty_Name()
    {
        var result = HomeScreen.GetWelcomeMessage("");

        Assert.Equal("Dobrodošao, ", result);
    }

    [Fact]
    public void GetWelcomeMessage_With_Null()
    {
        var result = HomeScreen.GetWelcomeMessage(null);

        Assert.Equal("Dobrodošao, ", result);
    }
}