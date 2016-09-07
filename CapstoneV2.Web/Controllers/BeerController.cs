using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapstoneV2.Data;
using CapstoneV2.Models.Interfaces;

namespace CapstoneV2.Web.Controllers
{
    public class BeerController : Controller
    {
        private IRepository _repo = RepositoryFactory.CreateRepository();
        // GET: Beer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult All()
        {
            var beers = _repo.GetAllBeers();
            return View(beers);
        }

        public ActionResult Details(int id)
        {
            var beer = _repo.GetBeerById(id);
            return View(beer);
        }
        
    }
}