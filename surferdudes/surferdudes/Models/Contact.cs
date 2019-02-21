using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace surferdudes.Models
{
    public class Contact
    {
        public int ID { get; set; }

        public string Voornaam { get; set; }

        public string Achternaam { get; set; }

        public string Telefoonnummer { get; set; }

        public string Land { get; set; }

        public string Email { get; set; }
    }
}