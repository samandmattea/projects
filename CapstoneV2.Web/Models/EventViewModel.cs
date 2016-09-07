using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapstoneV2.Data;
using CapstoneV2.Models.Data;

namespace CapstoneV2.Web.Models
{
    public class EventViewModel
    {
        public Event Event { get; set; }

        public List<SelectListItem> VenueItems { get; set; }

        public EventViewModel()
        {
            VenueItems = new List<SelectListItem>();
        }

        public void SetSelectListItems()
        {
            var repo = new DbRepository();

            var venues = repo.GetAllVenues();
            foreach (var venue in venues)
            {
                VenueItems.Add(new SelectListItem
                {
                    Text = venue.Name,
                    Value = venue.VenueId.ToString()
                });
            }
        }
    }
}