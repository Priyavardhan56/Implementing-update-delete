using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace Theme.Models
{
    public class Register
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Conformpassword { get; set; }
    }
    public class LoginDetails
    {
        [Required(ErrorMessage = "Please enter UserName")]
        [Display(Name = "Enter UserName:")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter Password")]
        [Display(Name = "Enter Password:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

        
 


