using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Theme.Models
{
    public class User
    {
        [Display(Name = "UserId")]
        public string RoleName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int HospitalId { get; set; }
        public string EntryBy { get; set; }
        public int IsActive { get; set; }
        public string EntryDate { get; set; }

    }
}