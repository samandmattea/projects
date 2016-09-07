using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CapstoneV2.Models.Data;

namespace CapstoneV2.Web.Models
{
    public class ContactFormViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Message")]
        public string Message { get; set; }

        [Required]
        [Display(Name="Your Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}