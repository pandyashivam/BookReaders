using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookReaders.Models
{
    public class SignUpUserModel
    {
        [Required(ErrorMessage ="Please enter your email")]
        [Display(Name ="Email address")]
        [EmailAddress(ErrorMessage ="Please enter a valid email")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Required(ErrorMessage ="Please enter a strong password")]
        [Compare("ConfirmPassword", ErrorMessage ="Password does not match & password must in 8 char , digit and special symbol")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage ="Please confirm your password")]
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        public string  ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter your Firstname")]
        [Display(Name = "Firstname")]
        public string FistName { get; set; }

        [Required(ErrorMessage = "Please enter your Lastname")]
        [Display(Name = "Lastname")]
        public string LastName { get; set; }



        [Required(ErrorMessage = "Please enter your address")]
        [Display(Name = "Address")]
        [StringLength(500)]
        public string Address { get; set; }

       


    }
}
