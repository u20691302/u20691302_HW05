using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u20691302_HW05.Models
{
    public class booksVM
    {
        public books book { get; set; }
        public authors author { get; set; }
        public types type { get; set; }
        public borrows borrow { get; set; }
    }
}