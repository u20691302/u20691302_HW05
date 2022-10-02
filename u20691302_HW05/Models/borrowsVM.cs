using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u20691302_HW05.Models
{
    public class borrowsVM
    {
        public books book { get; set; }
        public borrows borrow { get; set; }
        public students student { get; set; }

        public string getStatus()
        {
            string status = "";

            if (borrow.broughtDate != null)
            {
                status = "Available";
            }
            else
            {
                status = "Book out";
            }
            return status;
        }
    }
}