using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Theme.Models
{
    public class Vitals
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        public string DoctorName { get; set; }

        public string PatientName { get; set; }
        public string HospitalName { get; set; }
        public string BloodPressure { get; set; }
        public string Temperature { get; set; }

        public string Pulse { get; set; }
        public string EntryDate { get; set; }



    }
}