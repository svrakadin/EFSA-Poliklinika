using DesktopDemo;
using DesktopDemo.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Xunit;

public class LoginTests
{
    private string testFile = "test_users.json";

    private void SetupUsers()
    {
        var users = new List<User>
        {
            new User { Name = "test", Password = "123" },
            new User { Name = "din", Password = "abc" }
        };

        string json = JsonConvert.SerializeObject(users);
        File.WriteAllText(testFile, json);
    }

    [Fact]
    public void Authenticate_ValidUser_ReturnsUser()
    {
        SetupUsers();

        var result = LoginScreen.Authenticate("test", "123", testFile);

        Assert.NotNull(result);
        Assert.Equal("test", result.Name);
    }

    [Fact]
    public void Authenticate_WrongPassword_ReturnsNull()
    {
        SetupUsers();

        var result = LoginScreen.Authenticate("test", "wrong", testFile);

        Assert.Null(result);
    }

    [Fact]
    public void Authenticate_UserNotFound_ReturnsNull()
    {
        SetupUsers();

        var result = LoginScreen.Authenticate("nepostoji", "123", testFile);

        Assert.Null(result);
    }

    [Fact]
    public void Authenticate_FileDoesNotExist_ReturnsNull()
    {
        if (File.Exists(testFile))
            File.Delete(testFile);

        var result = LoginScreen.Authenticate("test", "123", testFile);

        Assert.Null(result);
    }
}