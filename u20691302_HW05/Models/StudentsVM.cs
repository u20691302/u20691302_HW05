using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u20691302_HW05.Models
{
    public class StudentsVM
    {
        public students student { get; set; }
        public List<borrowsVM> borrow { get; set; }

        public string getStatus()
        {
            string status = "";
            if (borrow.Select(bd => bd.borrow.broughtDate).Contains(default(DateTime)))
            {
                status = "Book out";
            }
            else
            {
                status = "Available";
            }
            return status;
        }
    }
}