using DesktopDemo.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace DesktopDemo
{
    public partial class RequestsScreen : Page
    {
        public RequestsScreen()
        {
            InitializeComponent();
            LoadRequests();
        }

        private void LoadRequests()
        {
            string folderPath = @"C:\Users\dinsv\OneDrive\Desktop\EFSA-Poliklinika\DesktopDemo\Data";
            string filePath = Path.Combine(folderPath, "zahtjevi.json");

            RequestsList.ItemsSource = LoadRequestsFromFile(filePath);
        }

        public static List<Zahtjev> LoadRequestsFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                return new List<Zahtjev>();

            string json = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(json))
                return new List<Zahtjev>();

            return JsonConvert.DeserializeObject<List<Zahtjev>>(json)
                   ?? new List<Zahtjev>();
        }

        private void CreateRequest_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateRequestScreen());
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomeScreen(Session.UserName));
        }
    }
}