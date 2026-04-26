using DesktopDemo;
using DesktopDemo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

public class RegistrationTests
{
    private string testFile = "test_users_reg.json";

    [Fact]
    public void Register_Fails_When_TOS_NotAccepted()
    {
        var result = RegistrationScreen.RegisterUser(
            "Din", "Svraka", "Sarajevo", "123",
            DateTime.Now, false, testFile);

        Assert.False(result.success);
    }

    [Fact]
    public void Register_Fails_When_DateMissing()
    {
        var result = RegistrationScreen.RegisterUser(
            "Din", "Svraka", "Sarajevo", "123",
            null, true, testFile);

        Assert.False(result.success);
    }

    [Fact]
    public void Register_Fails_When_FieldsEmpty()
    {
        var result = RegistrationScreen.RegisterUser(
            "", "Svraka", "Sarajevo", "123",
            DateTime.Now, true, testFile);

        Assert.False(result.success);
    }
}