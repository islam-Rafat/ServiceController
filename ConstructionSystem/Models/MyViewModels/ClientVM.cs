using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConstructionSystem.Models.MyViewModels
{
    public class ClientVM
    {
        public string userId { get; set; }

        [Required]
        [Display(Name ="Client Name")]
        public string userName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage ="Please Enter a Valid Email Address")]
        public string email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Phone Number")]
        [StringLength(15,MinimumLength =11,ErrorMessage = "Please Enter a Valid Phone Number")]
        public string phone { get; set; }

        [Display(Name = "City")]
        public string city { get; set; }

        public string role { get; set; }

        [Range(2,120)]
        [Display(Name = "Age")]
        public int? age { get; set; }

        [Display(Name = "Gender")]
        public bool? gender { get; set; }
    }
}