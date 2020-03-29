using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Theme.Models
{
        public class Role
        {
        [Display(Name="RoleId")]
        public int RoleId { get; set; }
            public string RoleName { get; set; }
            public string RoleDescription { get; set; }
            public string EntryBy { get; set; }
            public string EntryDateTime { get; set; }



        }
    }
