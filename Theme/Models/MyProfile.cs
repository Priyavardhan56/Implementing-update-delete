using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Theme.Models
{
    public class MyProfile
    {
        [Required]
        public String Name { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public String LicenceNumber { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public String Address { get; set; }

    }
}