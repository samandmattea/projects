using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapstoneV2.BLL;
using CapstoneV2.Data;
using CapstoneV2.Models.Data;
using CapstoneV2.Web.Models;
using X.PagedList;

namespace CapstoneV2.Web.Controllers
{
    public class HomeController : Controller
    {
        private BlogPostOperations _blops = new BlogPostOperations();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Got a unique question?  Ask the team here.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactFormViewModel vm)
        {
            var repo = RepositoryFactory.CreateRepository();
            var form = new ContactForm
            {
                Name = vm.Name,
                Email = vm.Email,
                Message = vm.Message,
                DateSent = DateTime.Now
            };
            repo.AddContactForm(form);
            return RedirectToAction("Index", "Home");
        }

        //Testing new pagination/routing
        public ActionResult Blog(int? id, int? page)
        {
            var repo = RepositoryFactory.CreateRepository();
            var vm = new BlogVM();

            vm.BlogEntries = _blops.GetUnexpiredPosts();
            
            if (id != null)
            {
                vm.BlogEntries = _blops.BlogsByTag(id);
            }
            var pageNumber = page ?? 1;

            // The 2nd param in the next line defines the size of the page
            vm.BlogEntries = vm.BlogEntries.ToPagedList(pageNumber, 5);
            vm.Tags = repo.GetAllTags();
            return View(vm);
        }

        public ActionResult Employees()
        {
            var repo = RepositoryFactory.CreateRepository();
            List<User> users = repo.GetAllEmployees();
            return View(users);
        }

        //blog archives
        public ActionResult Archives(int? id, int? page)
        {
            var vm = new BlogVM();
            var repo = RepositoryFactory.CreateRepository();
            //TODO: See if this works for consolidating getting posts by tag id
            vm.BlogEntries = _blops.GetBlogArchives(id);

            var pageNumber = page ?? 1;

            // The 2nd param in the next line defines the size of the page
            vm.BlogEntries = vm.BlogEntries.ToPagedList(pageNumber, 5);

            vm.Tags = repo.GetAllTags();
            return View(vm);
        }

        public ActionResult FAQ()
        {
            return View();
        }

        public ActionResult ViewStaticPage(int id)
        {
            var repo = RepositoryFactory.CreateRepository();
            var page = repo.GetStaticPage(id);

            return View(page);
        }
        
    }
}