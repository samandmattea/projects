using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CapstoneV2.Models.Data
{
    public class StaticPage
    {
        public int PageId { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        public string Body { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

    }
}
