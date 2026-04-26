using Xunit;
using System;
using System.Collections.Generic;
using DesktopDemo.Models;

public class CreateRequestTests
{
    [Fact]
    public void Test1_Validation_Should_Fail_When_Fields_Are_Empty()
    {
        string examType = "";
        string time = "";
        string specialist = "";
        string residence = "";
        string healthCard = "";
        DateTime? date = null;

        bool isValid =
            !string.IsNullOrWhiteSpace(examType) &&
            !string.IsNullOrWhiteSpace(time) &&
            !string.IsNullOrWhiteSpace(specialist) &&
            !string.IsNullOrWhiteSpace(residence) &&
            !string.IsNullOrWhiteSpace(healthCard) &&
            date != null;

        Assert.False(isValid);
    }

    [Fact]
    public void Test2_Validation_Should_Pass_When_All_Fields_Are_Filled()
    {
        string examType = "Pregled";
        string time = "12:00";
        string specialist = "Kardiolog";
        string residence = "Sarajevo";
        string healthCard = "12345";
        DateTime? date = DateTime.Now;

        bool isValid =
            !string.IsNullOrWhiteSpace(examType) &&
            !string.IsNullOrWhiteSpace(time) &&
            !string.IsNullOrWhiteSpace(specialist) &&
            !string.IsNullOrWhiteSpace(residence) &&
            !string.IsNullOrWhiteSpace(healthCard) &&
            date != null;

        Assert.True(isValid);
    }

    [Fact]
    public void Test3_Should_Create_Request_Object_Correctly()
    {
        var zahtjev = new Zahtjev
        {
            TipPregleda = "Pregled",
            Datum = DateTime.Now.ToString("dd.MM.yyyy"),
            Vrijeme = "12:00",
            Specijalista = "Dermatolog",
            Mjesto = "Mostar",
            Karton = "99999",
            Status = "NA ČEKANJU"
        };

        Assert.Equal("Pregled", zahtjev.TipPregleda);
        Assert.Equal("NA ČEKANJU", zahtjev.Status);
    }

    [Fact]
    public void Test4_Should_Add_Request_To_List()
    {
        var lista = new List<Zahtjev>();

        var novi = new Zahtjev
        {
            TipPregleda = "RTG",
            Status = "NA ČEKANJU"
        };

        lista.Add(novi);

        Assert.Single(lista);
        Assert.Equal("RTG", lista[0].TipPregleda);
    }
}