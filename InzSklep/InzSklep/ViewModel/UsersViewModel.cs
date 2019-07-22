using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InzSklep.ViewModel
{
    public class UserViewModel
    {
        public InzSklep.Models.ApplicationUser user { get; set; }
        public string role { get; set; }
    }
}