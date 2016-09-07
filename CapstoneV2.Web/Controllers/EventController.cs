using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapstoneV2.BLL;
using CapstoneV2.Web.Models;

namespace CapstoneV2.Web.Controllers
{
    public class EventController : Controller
    {
        private static EventOperations _eops = new EventOperations();
        // GET: Event
        public ActionResult Index()
        {
            var vm = new EventsVM();
            vm.Events = _eops.UpcomingEvents();
            vm.Events = _eops.SetGMapUrls(vm.Events);
            return View(vm);
        }
    }
}