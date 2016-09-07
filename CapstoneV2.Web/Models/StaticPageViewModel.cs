using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapstoneV2.Models.Data;

namespace CapstoneV2.Web.Models
{
    public class StaticPageViewModel
    {
        public int PageId { get; set; }

        [DisplayName("Title")]
        [Required]
        public string Title { get; set; }
        
        [DisplayName("Body Content")]
        [Required]
        [AllowHtml]
        public string Body { get; set; }

        [DisplayName("Date Created")]
        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public StaticPageViewModel() { }

        public StaticPageViewModel(StaticPage p)
        {
            PageId = p.PageId;
            Title = p.Title;
            Body = p.Body;
            DateCreated = p.DateCreated;
            DateUpdated = p.DateUpdated;
        }


    }
}