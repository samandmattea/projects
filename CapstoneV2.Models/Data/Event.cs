using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CapstoneV2.Models.Data
{
    public class Event
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Venue Venue { get; set; }
        public string GmapsUrl { get; set; }
        public string ImgPath { get; set; }


        // This list is for an image gallery
        //public List<Image> Images { get; set; }
        //public List<string> ImgPaths { get; set; }
    }
}