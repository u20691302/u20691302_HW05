using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace u20691302_HW05.Models
{
    public class borrows
    {
        [DisplayName("#")]
        public int borrowId { get; set; }
        [DisplayName("Taken Date")]
        public DateTime takenDate { get; set; }
        [DisplayName("Brought Date")]
        public DateTime broughtDate { get; set; }
        public int studentId { get; set; }
        public int bookId { get; set; }
    }
}