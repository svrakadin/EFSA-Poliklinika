using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopDemo.Models
{
    public class Zahtjev
    {
        public string TipPregleda { get; set; }
        public string Datum { get; set; }
        public string Vrijeme { get; set; }
        public string Specijalista { get; set; }
        public string Mjesto { get; set; }
        public string Karton { get; set; }
        public string Status { get; set; }
    }
}
