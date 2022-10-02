using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace u20691302_HW05.Models
{
    public class students
    {
        [DisplayName("#")]
        public int studentId { get; set; }
        [DisplayName("Name")]
        public string name { get; set; }
        [DisplayName("Surname")]
        public string surname { get; set; }
        public DateTime birthdate { get; set; }
        public string gender { get; set; }
        [DisplayName("Class")]
        public string Class { get; set; }
        [DisplayName("Points")]
        public int point { get; set; }
    }
}