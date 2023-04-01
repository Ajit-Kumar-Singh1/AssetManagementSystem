using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementSystem.Models.ViewModel
{
    public class SignupUserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your full name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter email id")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid email id")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter mobile no.")]
        [Display(Name = "Mobile Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Enter a valid mobile no.")]
        public long? Mobile { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm password")]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = ("Password didn't match"))]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }
    }
}
