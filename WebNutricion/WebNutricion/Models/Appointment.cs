using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebNutricion.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string User { get; set; }
        public string Status { get; set; } 
    }
}