using DesktopDemo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace DesktopDemo
{
    public partial class CreateRequestScreen : Page
    {
        public CreateRequestScreen()
        {
            InitializeComponent();
        }

        private void SubmitRequest_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ExamType.Text) ||
                Date.SelectedDate == null ||
                string.IsNullOrWhiteSpace(Time.Text) ||
                string.IsNullOrWhiteSpace(Specialist.Text) ||
                string.IsNullOrWhiteSpace(Residence.Text) ||
                string.IsNullOrWhiteSpace(HealthCard.Text))
            {
                MessageBox.Show("Sva polja moraju biti popunjena!");
                return;
            }

            string folderPath = @"C:\Users\dinsv\OneDrive\Desktop\EFSA-Poliklinika\DesktopDemo\Data";
            string filePath = Path.Combine(folderPath, "zahtjevi.json");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            List<Zahtjev> zahtjevi = new List<Zahtjev>();

            if (File.Exists(filePath))
            {
                string existing = File.ReadAllText(filePath);

                if (!string.IsNullOrWhiteSpace(existing))
                {
                    zahtjevi = JsonConvert.DeserializeObject<List<Zahtjev>>(existing)
                               ?? new List<Zahtjev>();
                }
            }
            else
            {
                File.WriteAllText(filePath, "[]");
            }

            Zahtjev novi = new Zahtjev
            {
                TipPregleda = ExamType.Text,
                Datum = Date.SelectedDate?.ToString("dd.MM.yyyy"),
                Vrijeme = Time.Text,
                Specijalista = Specialist.Text,
                Mjesto = Residence.Text,
                Karton = HealthCard.Text,
                Status = "NA ČEKANJU"
            };

            zahtjevi.Add(novi);

            string json = JsonConvert.SerializeObject(zahtjevi, Formatting.Indented);
            File.WriteAllText(filePath, json);

            MessageBox.Show("Zahtjev uspješno kreiran!");
            NavigationService.Navigate(new RequestsScreen());
        }
    }
}