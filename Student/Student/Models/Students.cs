using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Student.Models
{
    public class Students
    {
        [Required(ErrorMessage ="Please provide ID")]
        [RegularExpression(@"^\d{2}-\d{5}-\d{1}$", ErrorMessage = "Id must follow XX-XXXXX-X")]


        public int id { get; set; }
        [Required(ErrorMessage ="Please enter a name ")]
        [RegularExpression(@"(?:[a-zA-Z][a-zA-Z\. _]+)+[_a-zA-Z]", ErrorMessage = "Enter a valid Name")]
        public string name { get; set; }
        [Required(ErrorMessage ="Please Provide your  Date of birth")]
        
        public DateTime dob { get; set; }
        [Required(ErrorMessage ="please enter a password")]
        [MaxLength(8,ErrorMessage ="Password must be greater than 8 character ")]
        public string password { get; set; }
       
            
            [Compare("password")]
        public string confirmpassword { get; set; }
        [Required(ErrorMessage ="Please enater a email")]
        [EmailAddress(ErrorMessage ="Please enter a valid email")]
        public string email { get; set; }
    }

}