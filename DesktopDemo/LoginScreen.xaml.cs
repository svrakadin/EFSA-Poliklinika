using DesktopDemo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DesktopDemo
{
    public partial class LoginScreen : Page
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationScreen());
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            string userName = usernameTextBox.Text;
            string password = passwordTextBox.Password;

            string folderPath = @"C:\Users\dinsv\OneDrive\Desktop\EFSA-Poliklinika\DesktopDemo\Data";
            string filePath = Path.Combine(folderPath, "users.json");

            if (!File.Exists(filePath))
            {
                MessageBox.Show("No registered users found.");
                return;
            }

            string json = File.ReadAllText(filePath);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();

            User foundUser = users.FirstOrDefault(u =>
                u.Name == userName && u.Password == password);

            if (foundUser != null)
            {
                Session.UserName = foundUser.Name;
                NavigationService.Navigate(new HomeScreen(foundUser.Name));
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }
    }
}