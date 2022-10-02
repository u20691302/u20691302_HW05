using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace u20691302_HW05.Models
{
    public class authors
    {
        public int authorId { get; set; }
        public string name { get; set; }
        [DisplayName("Author")]
        public string surname { get; set; }
    }
}