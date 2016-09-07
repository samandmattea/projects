using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CapstoneV2.Models.Data;

namespace CapstoneV2.Web.Models
{
    public class StyleViewModel
    {
        public int StyleId { get; set; }

        [DisplayName("Name")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Description")]
        [Required]
        public string Description { get; set; }

        public StyleViewModel() { }

        public StyleViewModel(Style s)
        {
            StyleId = s.StyleId;
            Name = s.Name;
            Description = s.Description;
        }
    }
}