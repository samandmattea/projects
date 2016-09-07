using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CapstoneV2.Models.Data;

namespace CapstoneV2.Web.Models
{
    public class EventsVM
    {
        public IEnumerable<Event> Events { get; set; }
    }
}