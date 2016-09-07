using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CapstoneV2.Models.Data
{
    public class BlogEntry
    {
        public int EntryId { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        public string Body { get; set; }

        //Optional, in case blog pertains to a specific event or beer
        public Event Event { get; set; }
        public Beer Beer { get; set; }

        public DateTime DatePosted { get; set; }
        public DateTime? DateExpire { get; set; }
        public DateTime? DateUpdated { get; set; }
        //public List<Image> Images { get; set; }
        public List<Tag> Tags { get; set; }
        public bool IsApproved { get; set; }

        public BlogEntry()
        {
            Tags = new List<Tag>();
        }
    }
}