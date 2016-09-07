using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapstoneV2.Data;
using CapstoneV2.Models.Data;
using CapstoneV2.Models.Interfaces;

namespace CapstoneV2.BLL
{
    public class EventOperations
    {
        private MapOperations _mapops = new MapOperations();

        private IRepository _repo = RepositoryFactory.CreateRepository();

        public IEnumerable<Event> SetGMapUrls(IEnumerable<Event> events)
        {
            foreach (var e in events)
            {
                if (!String.IsNullOrEmpty(e.Venue.Contact.StreetAddress) &&
                    !String.IsNullOrEmpty(e.Venue.Contact.City) &&
                    !String.IsNullOrEmpty(e.Venue.Contact.State))
                {
                    e.GmapsUrl = _mapops.ConvertAddressToUrl(e.Venue.Contact);
                }
            }
            return events;
        }

        public IEnumerable<Event> UpcomingEvents()
        {
            return _repo.GetAllEvents().Where(d => d.StartDate >= DateTime.Today);
        }

        public IEnumerable<Event> PastEvents()
        {
            return _repo.GetAllEvents().Where(d => d.StartDate <= DateTime.Today);
        }
    }
}
