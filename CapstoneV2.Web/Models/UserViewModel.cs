using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapstoneV2.Data;
using CapstoneV2.Models.Data;

namespace CapstoneV2.Web.Models
{
    public class UserViewModel
    {
        //TODO: REMOVE THIS.  It has been rendered erroneous by the RegisterViewModel
        public User User { get; set; }
        public List<SelectListItem> AccessLevelItems { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public UserViewModel()
        {
            AccessLevelItems = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value = "0",
                    Text = "Admin"
                },
                new SelectListItem()
                {
                    Value = "1",
                    Text = "Writer"
                },
                new SelectListItem()
                {
                    Value = "2",
                    Text = "Contributor"
                }
            };
        }
    }
}