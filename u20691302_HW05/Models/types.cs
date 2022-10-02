using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace u20691302_HW05.Models
{
    public class types
    {
        public int typeId { get; set; }
        [DisplayName("Type")]
        public string name { get; set; }
    }
}