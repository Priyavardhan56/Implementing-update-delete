using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Theme.Models
{
    public class Hospital
    {


        [Display(Name = "HospitalId")]
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
            public string HospitalAddress { get; set; }
            public string HospitalCity { get; set; }
            public string HospitalState { get; set; }
            public string HospitalCountry { get; set; }
            public string HospitalPhone { get; set; }
            public string HospitalEmail { get; set; }
            public string HospitalLogo { get; set; }
            public int IsActive { get; set; }
            public string EntryDateTime { get; set; }
            public string EntryBy { get; set; }




        }
    }
