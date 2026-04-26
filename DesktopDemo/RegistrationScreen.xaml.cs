using DesktopDemo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace DesktopDemo
{
    public partial class RegistrationScreen : Page
    {
        public RegistrationScreen()
        {
            InitializeComponent();
        }

        private void SubmitButtonClick(object sender, RoutedEventArgs e)
        {
            bool userAcceptedToS = tosCheckBox.IsChecked == true;

            if (!userAcceptedToS)
            {
                MessageBox.Show("You must accept the Terms of Service to register.");
                return;
            }

            string firstName = Name.Text;
            string lastName = Surname.Text;
            string homeTown = City.Text;
            string password = Password.Password;

            if (Date.SelectedDate == null)
            {
                MessageBox.Show("Please select date of birth.");
                return;
            }

            DateTime dateOfBirth = Date.SelectedDate.Value;

            string folderPath = @"C:\Users\dinsv\OneDrive\Desktop\EFSA-Poliklinika\DesktopDemo\Data";
            string filePath = Path.Combine(folderPath, "users.json");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            List<User> users = new List<User>();

            if (File.Exists(filePath))
            {
                string existingData = File.ReadAllText(filePath);

                if (!string.IsNullOrWhiteSpace(existingData))
                {
                    users = JsonConvert.DeserializeObject<List<User>>(existingData)
                             ?? new List<User>();
                }
            }
            else
            {
                File.WriteAllText(filePath, "[]");
            }

            User newUser = new User
            {
                Name = firstName,
                Surname = lastName,
                City = homeTown,
                DateOfBirth = dateOfBirth,
                Password = password
            };

            users.Add(newUser);

            User foundUser = users.FirstOrDefault(u =>
                u.Name == firstName);
            Session.UserName = foundUser.Name;

            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(filePath, json);

            MessageBox.Show("Registration successful!");
            NavigationService.Navigate(new HomeScreen(firstName));
        }
    }
}