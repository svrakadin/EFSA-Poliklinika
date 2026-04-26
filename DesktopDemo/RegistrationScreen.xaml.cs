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
    public partial class RegistrationScreen : Page
    {
        public RegistrationScreen()
        {
            InitializeComponent();
        }

        private void SubmitButtonClick(object sender, RoutedEventArgs e)
        {
            string folderPath = @"C:\Users\dinsv\OneDrive\Desktop\EFSA-Poliklinika\DesktopDemo\Data";
            string filePath = Path.Combine(folderPath, "users.json");

            var result = RegisterUser(
                Name.Text,
                Surname.Text,
                City.Text,
                Password.Password,
                Date.SelectedDate,
                tosCheckBox.IsChecked == true,
                filePath
            );

            if (!result.success)
            {
                if (result.message == "TOS")
                    MessageBox.Show("You must accept the Terms of Service to register.");
                else if (result.message == "DATE")
                    MessageBox.Show("Please select date of birth.");
                else if (result.message == "FIELDS")
                    MessageBox.Show("All fields are required.");

                return;
            }

            Session.UserName = Name.Text;

            MessageBox.Show("Registration successful!");
            NavigationService.Navigate(new HomeScreen(Name.Text));
        }

        public static (bool success, string message) RegisterUser(
            string firstName,
            string lastName,
            string homeTown,
            string password,
            DateTime? dateOfBirth,
            bool acceptedTos,
            string filePath)
        {
            if (!acceptedTos)
                return (false, "TOS");

            if (dateOfBirth == null)
                return (false, "DATE");

            if (string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(homeTown) ||
                string.IsNullOrWhiteSpace(password))
                return (false, "FIELDS");

            string folderPath = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

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
                DateOfBirth = dateOfBirth.Value,
                Password = password
            };

            users.Add(newUser);

            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(filePath, json);

            return (true, "OK");
        }
    }
}