using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace u20691302_HW05.Models
{
    public class books
    {
        [DisplayName("#")]
        public int bookId { get; set; }
        [DisplayName("Name")]
        public string name { get; set; }
        [DisplayName("Page Count")]
        public int pagecount { get; set; }
        [DisplayName("Points")]
        public int point { get; set; }
        public int authorId { get; set; }
        public int typeId { get; set; }
    }
}