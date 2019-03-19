using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace surferdudes.Models
{
    public class Nieuwsbriefmodel
    {
        public int ID { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Geslacht { get; set; }
        public string Land { get; set; }
        public string Email { get; set; }

    }
}

