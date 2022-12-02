using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiveApp.Models
{
    public class SignUpUserModel
    {
        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name: ")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name: ")]
        public string LastName { get; set; }
        [Display(Name = "Date Of Birth: ")]
        public DateTime? DateOfBirth { get; set; }
        [Required(ErrorMessage = "Please enter your email.")]
        [Display(Name = "Email: ")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password: ")]
        [Compare("ConfirmPassword", ErrorMessage = "Password doesn't match.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password: ")]
        public string ConfirmPassword { get; set; }
    }
}
