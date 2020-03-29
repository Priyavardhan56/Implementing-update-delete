using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Theme.Models.Doctor
{
    public class PatientSlip
    {
        [Required]
        public int PatientCheckUpId { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        public int HospitalId { get; set; }
        [Required]
        public string Diagnosis { get; set; }
        [Required]
        public string RefferTo { get; set; }
        [Required]
        public string RefferRemarks { get; set; }
        
    }
}