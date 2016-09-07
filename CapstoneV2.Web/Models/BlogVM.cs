using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CapstoneV2.Models.Data;

namespace CapstoneV2.Web.Models
{
    public class BlogVM
    {
        public IEnumerable<BlogEntry> BlogEntries { get; set; }
        public List<Tag> Tags { get; set; }

        public BlogVM()
        {
            BlogEntries = new List<BlogEntry>();
            Tags = new List<Tag>();
        }
    }
}