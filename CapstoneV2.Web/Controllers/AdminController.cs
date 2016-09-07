using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using CapstoneV2.BLL;
using CapstoneV2.Data;
using CapstoneV2.Models.Data;
using CapstoneV2.Models.Enums;
using CapstoneV2.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace CapstoneV2.Web.Controllers
{
    
    [Authorize] 
    public class AdminController : Controller
    {
        BlogPostOperations blops = new BlogPostOperations();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        #region Beer Management
        //  manage
        
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult ManageBeers()
        {
            var repo = RepositoryFactory.CreateRepository();
            var beers = repo.GetAllBeers();
            return View(beers);
        }

        //  add
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult AddBeer()
        {
            var vm = new NewBeerViewModel();
            vm.SetSelectListItems();
            return View(vm);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddBeer(NewBeerViewModel vm, HttpPostedFileBase file)
        {
            var repo = RepositoryFactory.CreateRepository();

            // TODO: See if there is a way to outsource all of this initialization to the BLL
            var beer = new Beer
            {
                Name = vm.Name,
                ABV = vm.ABV,
                Description = vm.Description,
                IsAvailable = vm.IsAvailable,
                IsFlagship = vm.IsFlagship,
                ReleaseDate = vm.ReleaseDate,
                Season = vm.Season
            };

            if (vm.IBU.HasValue)
                beer.IBU = vm.IBU.Value;

            if (vm.StyleId.HasValue)
                beer.Style = repo.GetStyleById(vm.StyleId.Value);
            else
            {
                beer.Style = new Style
                {
                    Name = vm.StyleName,
                    Description = vm.StyleDescription
                };
                beer.Style = repo.AddStyle(beer.Style);
            }

            if (vm.SeriesId.HasValue)
                beer.Series = repo.GetSeriesById(vm.SeriesId.Value);
            else if (!string.IsNullOrEmpty(vm.SeriesName))
            {
                beer.Series = new Series
                {
                    Name = vm.SeriesName,
                    Description = vm.SeriesDescription
                };

                beer.Series = repo.AddSeries(beer.Series);
            }
            else beer.Series = null;

            if (vm.CollabId.HasValue)
                beer.Collaborator = repo.GetCollaboratorById(vm.CollabId.Value);
            else if (!String.IsNullOrEmpty(vm.CollabName))
            {
                beer.Collaborator = new Collaborator
                {
                    Name = vm.CollabName,
                    Description = vm.CollabDescription,
                    //Website = vm.CollabWebsite,
                    Contact = new ContactInfo
                    {
                        StreetAddress = vm.CollabStreetAddress,
                        City = vm.CollabCity,
                        State = vm.CollabState,
                        Zip = vm.CollabZip
                    }
                };
                beer.Collaborator.Contact = repo.AddContact(beer.Collaborator.Contact);
                beer.Collaborator = repo.AddCollaborator(beer.Collaborator);
            }
            else beer.Collaborator = null;

            beer.ImgPath = UploadImage(file);
            
            repo.AddBeer(beer);

            return RedirectToAction("ManageBeers", "Admin");
        }

        //  edit
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult EditBeer(int id)
        {
            var repo = RepositoryFactory.CreateRepository();
            var beer = repo.GetBeerById(id);
            var vm = new NewBeerViewModel(beer);

            vm.SetSelectListItems();
            return View(vm);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditBeer(NewBeerViewModel vm, HttpPostedFileBase file)
        {
            var repo = RepositoryFactory.CreateRepository();
            var beer = new Beer
            {
                BeerId = vm.BeerId,
                Name = vm.Name,
                ABV = vm.ABV,
                Description = vm.Description,
                IsAvailable = vm.IsAvailable,
                IsFlagship = vm.IsFlagship,
                ReleaseDate = vm.ReleaseDate,
                Season = vm.Season
            };

            if (vm.IBU.HasValue)
                beer.IBU = vm.IBU.Value;

            if (!string.IsNullOrEmpty(vm.StyleName))
            {
                beer.Style = new Style
                {
                    Name = vm.StyleName,
                    Description = vm.StyleDescription
                };
                beer.Style = repo.AddStyle(beer.Style);
            }
            else if (vm.StyleId.HasValue)
                beer.Style = repo.GetStyleById(vm.StyleId.Value);


            if (!String.IsNullOrEmpty(vm.SeriesName))
            {
                beer.Series = new Series
                {
                    Name = vm.SeriesName,
                    Description = vm.SeriesDescription
                };

                beer.Series = repo.AddSeries(beer.Series);
            }
            else if (vm.SeriesId.HasValue)
                beer.Series = repo.GetSeriesById(vm.SeriesId.Value);
            else beer.Series = null;


            if (!string.IsNullOrEmpty(vm.CollabName))
            {
                beer.Collaborator = new Collaborator
                {
                    Name = vm.CollabName,
                    Description = vm.CollabDescription,
                    //Website = vm.CollabWebsite,
                    Contact = new ContactInfo
                    {
                        StreetAddress = vm.CollabStreetAddress,
                        City = vm.CollabCity,
                        State = vm.CollabState,
                        Zip = vm.CollabZip
                    }
                };

                beer.Collaborator.Contact = repo.AddContact(beer.Collaborator.Contact);
                beer.Collaborator = repo.AddCollaborator(beer.Collaborator);
            }
            else if (vm.CollabId.HasValue)
                beer.Collaborator = repo.GetCollaboratorById(vm.CollabId.Value);
            else beer.Collaborator = null;

            beer.ImgPath = file == null ? vm.ImgPath : UploadImage(file);

            repo.EditBeer(beer);
            return RedirectToAction("ManageBeers", "Admin");
        }

        //  delete
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult DeleteBeer(int id)
        {
            var repo = RepositoryFactory.CreateRepository();
            var beer = repo.GetBeerById(id);
            return View(beer);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult DeleteBeer(Beer beer)
        {
            var repo = RepositoryFactory.CreateRepository();
            repo.DeleteBeer(beer.BeerId);
            return RedirectToAction("ManageBeers", "Admin");
        }
        #endregion

        #region Beer Style Management
        //STYLES
        //  Manage
        [HttpGet]
        public ActionResult ManageStyles()
        {
            var repo = RepositoryFactory.CreateRepository();
            var styles = repo.GetAllStyles();
            return View(styles);
        }

        //  Add
        [HttpGet]
        public ActionResult AddStyle()
        {
            StyleViewModel svm = new StyleViewModel();
            return View(svm);
        }

        [HttpPost]
        public ActionResult AddStyle(StyleViewModel styleVM)
        {
            Style style = new Style()
            {
                Description = styleVM.Description,
                Name = styleVM.Name
            };
            var repo = RepositoryFactory.CreateRepository();
            repo.AddStyle(style);
            return RedirectToAction("ManageStyles", "Admin");
        }

        //  Edit

        [HttpGet]
        public ActionResult EditStyle(int id)
        {
            var repo = RepositoryFactory.CreateRepository();
            var style = repo.GetStyleById(id);
            var vm = new StyleViewModel(style);
            return View(vm);
        }

        [HttpPost]
        public ActionResult EditStyle(StyleViewModel vm)
        {
            var repo = RepositoryFactory.CreateRepository();
            var style = new Style
            {
                StyleId = vm.StyleId,
                Name = vm.Name,
                Description = vm.Description
            };
            repo.EditStyle(style);
            return RedirectToAction("ManageStyles", "Admin");
        }

        //  Delete

        [HttpGet]
        public ActionResult DeleteStyle(int id)
        {
            var repo = RepositoryFactory.CreateRepository();
            var style = repo.GetStyleById(id);
            return View(style);
        }

        [HttpPost]
        public ActionResult DeleteStyle(Style style)
        {
            var repo = RepositoryFactory.CreateRepository();
            repo.DeleteStyle(style.StyleId);
            return RedirectToAction("ManageStyles", "Admin");
        }
        #endregion

        #region Blog Management
        //BLOG POSTS
        //  Manage
        public ActionResult ManageBlog()
        {
            var repo = RepositoryFactory.CreateRepository();
            var blogs = repo.GetAllBlogEntries();
            return View(blogs);
        }
        //  Add
        [Authorize]
        [HttpGet]
        public ActionResult AddBlogEntry()
        {
            var vm = new BlogViewModel();
            vm.ExpireDate = null;
            vm.SetSelectListItems();
            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddBlogEntry(BlogViewModel vm/*, IEnumerable<HttpPostedFileBase> images*/)
        {
            var repo = RepositoryFactory.CreateRepository();
            var ops = new BlogPostOperations();

            var blog = new BlogEntry()
            {
                Title = vm.Title,
                Body = vm.Body,
                DateExpire = vm.ExpireDate,
                //Images = new List<Image>(),
                User = repo.GetUserbyAspId(User.Identity.GetUserId()),
                IsApproved = User.IsInRole("Admin")
            };
            #region Commented-out, multi-image upload method
            //TODO: MULTI-IMAGE, EVENTUALLY
            //foreach (var img in images)
            //{
            //    if (img != null && img.ContentLength > 0 && img.ContentType.Contains("image"))
            //    {
            //        try
            //        {
            //            string path = Path.Combine(Server.MapPath("~/App_Data"), Path.GetFileName(img.FileName));
            //            img.SaveAs(path);
            //            blog.Images.Add(new Image {ImgPath = path});
            //        }
            //        catch (Exception ex)
            //        {
            //            ViewBag.Message = "ERROR:" + ex.Message.ToString();
            //        }
            //    }
            //}
            #endregion

            var tags = ops.ParseTags(vm.Body, vm.TagInput);
            foreach (var tag in tags)
            {
                blog.Tags.Add(new Tag {Name = tag});
            }

            repo.AddBlogEntry(blog);

            return RedirectToAction("Index", "Admin");
        }

        //  Edit
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult EditBlogEntry(int id)
        {
            var repo = RepositoryFactory.CreateRepository();
            var blog = repo.GetBlogEntryById(id);
            var vm = new BlogViewModel(blog);
            vm.SetSelectListItems();
            return View(vm);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditBlogEntry(BlogViewModel vm)
        {
            var repo = RepositoryFactory.CreateRepository();
            var blog = new BlogEntry
            {
                Title = vm.Title,
                Body = vm.Body,
                IsApproved = User.IsInRole("Admin"),
                User = repo.GetUserbyAspId(User.Identity.GetUserId()),
                DatePosted = vm.PostDate,
                DateUpdated = DateTime.Today
            };
            
            var tags = blops.ParseTags(vm.Body, vm.TagInput);
            foreach (var tag in tags)
            {
                blog.Tags.Add(new Tag { Name = tag });
            }

            repo.EditBlogEntry(blog);
            return RedirectToAction("ManageBlog", "Admin");
        }
        //  Delete
        [Authorize(Roles = "Admin")] //TODO: RE-ENABLE LATER
        [HttpGet]
        public ActionResult DeleteBlogEntry(int id)
        {
            var repo = RepositoryFactory.CreateRepository();
            var blog = repo.GetBlogEntryById(id);
            return View(blog);
        }

        [Authorize(Roles = "Admin")] //TODO: RE-ENABLE LATER
        [HttpPost]
        public ActionResult DeleteBlogEntry(BlogEntry entry)
        {
            var repo = RepositoryFactory.CreateRepository();
            repo.DeleteBlogEntry(entry.EntryId);
            return RedirectToAction("ManageBlog", "Admin");
        }

        [Authorize(Roles = "Admin")] //TODO: RE-ENABLE LATER
        [HttpGet]
        public ActionResult ApproveBlogEntries()
        {
            List<BlogEntry> pendingEntries = blops.GetUnapprovedPosts();
            return View(pendingEntries);
        }

        [Authorize(Roles = "Admin")] //TODO: RE-ENABLE LATER
        [HttpPost]
        public ActionResult ApproveBlogEntries(List<BlogEntry> blogs)
        {
            //TODO-SD: The view will return a list of selected posts to be approved & posted
            return RedirectToAction("ManageBlog", "Admin");
        }

        [Authorize(Roles = "Admin")] //TODO: RE-ENABLE LATER
        [HttpGet]
        public ActionResult ApproveBlogEntry(int id)
        {
            var repo = RepositoryFactory.CreateRepository();
            BlogEntry blog = repo.GetBlogEntryById(id);

            return View(blog);
        }

        [Authorize(Roles = "Admin")] //TODO: RE-ENABLE LATER
        [HttpPost]
        public ActionResult ApproveBlogEntry(BlogEntry blog)
        {
            var repo = RepositoryFactory.CreateRepository();
            blog = repo.GetBlogEntryById(blog.EntryId);
            blog.IsApproved = true;
            repo.EditBlogEntry(blog);

            return RedirectToAction("ManageBlog", "Admin");
        }
        #endregion

        #region Event Management
        //EVENTS
        //  manage
        [Authorize(Roles = "Admin")]//TODO: RE-ENABLE FOR DEMO
        [HttpGet]
        public ActionResult ManageEvents()
        {
            var repo = RepositoryFactory.CreateRepository();
            var events = repo.GetAllEvents();
            return View(events);
        }
        //  add
        [Authorize(Roles = "Admin")]//TODO: RE-ENABLE FOR DEMO
        [HttpGet]
        public ActionResult AddEvent()
        {
            var vm = new NewEventViewModel();
            vm.SetSelectListItems();
            return View(vm);
        }

        [Authorize(Roles = "Admin")]//TODO: RE-ENABLE FOR DEMO
        [HttpPost]
        public ActionResult AddEvent(NewEventViewModel vm, HttpPostedFileBase file)
        {
            var repo = RepositoryFactory.CreateRepository();
            var e = new Event
            {
                Name = vm.Name,
                Description = vm.Description,
                StartDate = vm.DateStart,
                EndDate = vm.DateEnd
            };
            
            //if (vm.IsAllDay)
            //{
            //    if (vm.DateStart.HasValue)
            //        e.StartDate = vm.DateStart.Value;
            //    if (vm.DateEnd.HasValue)
            //        e.EndDate = vm.DateEnd.Value;
            //}
            //else
            //{
            //    if (vm.DateTimeStart.HasValue)
            //    {
            //        e.StartDate = vm.DateTimeStart.Value;
            //        e.StartTime = vm.DateTimeStart.Value;
            //    }
            //    if (vm.DateTimeEnd.HasValue)
            //        e.EndTime = vm.DateTimeEnd.Value;
            //}
                
            if(!string.IsNullOrEmpty(vm.VenueName))
            {
                e.Venue = new Venue
                {
                    Name = vm.VenueName,
                    Contact = new ContactInfo
                    {
                        StreetAddress = vm.VenueStreetAddress,
                        City = vm.VenueCity,
                        State = vm.VenueState,
                        Zip = vm.VenueZip,
                        Phone = vm.VenuePhone,
                        Email = vm.VenueEmail
                    }
                };
                repo.AddContact(e.Venue.Contact);
                e.Venue = repo.AddVenue(e.Venue);
            }
            if (e.Venue == null && vm.VenueId != null)
            {
                e.Venue = repo.GetVenueById(vm.VenueId.Value);
            }
              
            e.ImgPath = UploadImage(file);
            repo.AddEvent(e);

            return RedirectToAction("ManageEvents", "Admin");
        }

        //  
        [Authorize(Roles = "Admin")]//TODO: RE-ENABLE FOR DEMO
        [HttpGet]
        public ActionResult EditEvent(int id)
        {
            var repo = RepositoryFactory.CreateRepository();
            var e = repo.GetEventById(id);
            var vm = new NewEventViewModel
            {
                Name = e.Name,
                Description = e.Description,
                EventId = e.EventId,
                VenueId = e.Venue.VenueId
            };

            vm.SetSelectListItems();
            return View(vm);
        }

        [Authorize(Roles = "Admin")]//TODO: RE-ENABLE FOR DEMO
        [HttpPost]
        public ActionResult EditEvent(NewEventViewModel vm, HttpPostedFileBase file)
        {
            var repo = RepositoryFactory.CreateRepository();
            var e = new Event
            {
                Name = vm.Name,
                Description = vm.Description,
                StartDate = vm.DateStart,
                EndDate = vm.DateEnd
            };

            //if (vm.IsAllDay)
            //{
            //    if (vm.DateStart.HasValue)
            //        e.StartDate = vm.DateStart.Value;
            //    if (vm.DateEnd.HasValue)
            //        e.EndDate = vm.DateEnd.Value;
            //}
            //else
            //{
            //    if (vm.DateTimeStart.HasValue)
            //        e.StartTime = vm.DateTimeStart.Value;
            //    if (vm.DateTimeEnd.HasValue)
            //        e.EndTime = vm.DateTimeEnd.Value;
            //}

            if(!string.IsNullOrEmpty(vm.VenueName))
            {
                e.Venue = new Venue
                {
                    Name = vm.VenueName,
                    Contact = new ContactInfo
                    {
                        StreetAddress = vm.VenueStreetAddress,
                        City = vm.VenueCity,
                        State = vm.VenueState,
                        Zip = vm.VenueZip,
                        Phone = vm.VenuePhone,
                        Email = vm.VenueEmail
                    }
                };
                repo.AddContact(e.Venue.Contact);
                repo.AddVenue(e.Venue);
            } else if (vm.VenueId.HasValue)
                e.Venue = repo.GetVenueById(vm.VenueId.Value);

            e.ImgPath = file == null ? vm.ImgPath : UploadImage(file);

            repo.EditEvent(e);
            return RedirectToAction("ManageEvents", "Admin");
        }
        //  
        [Authorize(Roles = "Admin")]//TODO: RE-ENABLE FOR DEMO
        [HttpGet]
        public ActionResult DeleteEvent(int id)
        {
            var repo = RepositoryFactory.CreateRepository();
            var Event = repo.GetEventById(id);
            return View(Event);
        }

        [Authorize(Roles = "Admin")]//TODO: RE-ENABLE FOR DEMO
        [HttpPost]
        public ActionResult DeleteEvent(Event e)
        {
            var repo = RepositoryFactory.CreateRepository();
            repo.DeleteEvent(e.EventId);
            return RedirectToAction("ManageEvents", "Admin");
        }
        #endregion

        #region Venue Management
        //  manage
        [Authorize(Roles = "Admin")]//TODO: Re-enable authorization for deployment
        [HttpGet]
        public ActionResult ManageVenues()
        {
            var repo = RepositoryFactory.CreateRepository();
            List<Venue> venues = repo.GetAllVenues();
            return View(venues);
        }
        //  add
        [HttpGet]
        [Authorize(Roles = "Admin")]//TODO: Re-enable authorization for deployment
        public ActionResult AddVenue()
        {
            VenueViewModel vm = new VenueViewModel();
            return View(vm);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]//TODO: Re-enable authorization for deployment
        public ActionResult AddVenue(VenueViewModel vm, HttpPostedFileBase file)
        {
            var repo = RepositoryFactory.CreateRepository();
            //TODO
            var venue = new Venue
            {
                Name = vm.Name,
                Contact = new ContactInfo
                {
                    StreetAddress = vm.StreetAddress,
                    City = vm.City,
                    State = vm.State,
                    Zip = vm.Zip,
                    Email = vm.Email,
                    Phone = vm.Phone
                }
            };
            venue.ImgPath = UploadImage(file);
            repo.AddContact(venue.Contact);
            repo.AddVenue(venue);
            return RedirectToAction("ManageVenues", "Admin");
        }
        //  edit
        [HttpGet]
        [Authorize(Roles = "Admin")]//TODO: Re-enable authorization for deployment
        public ActionResult EditVenue(int id)
        {
            var repo = RepositoryFactory.CreateRepository();
            var venue = repo.GetVenueById(id);
            var vm = new VenueViewModel(venue);
            return View(vm);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]//TODO: Re-enable authorization for deployment
        public ActionResult EditVenue(VenueViewModel vm, HttpPostedFileBase file)
        {
            var repo = RepositoryFactory.CreateRepository();
            var contact = new ContactInfo
            {
                ContactId = vm.ContactId,
                StreetAddress = vm.StreetAddress,
                City = vm.City,
                State = vm.State,
                Zip = vm.Zip,
                Email = vm.Email,
                Phone = vm.Phone
            };
            var venue = new Venue
            {
                Name = vm.Name,
                VenueId = vm.VenueId,
                Contact = contact
            };
            venue.ImgPath = file == null ? vm.ImgPath : UploadImage(file);

            repo.EditContact(contact);
            repo.EditVenue(venue);
            return RedirectToAction("ManageVenues", "Admin");
        }
        //  delete
        [HttpGet]
        [Authorize(Roles = "Admin")]//TODO: Re-enable authorization for deployment
        public ActionResult DeleteVenue(int id)
        {
            var repo = RepositoryFactory.CreateRepository();
            var venue = repo.GetVenueById(id);
            return View(venue);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]//TODO: Re-enable authorization for deployment
        public ActionResult DeleteVenue(Venue venue)
        {
            var repo = RepositoryFactory.CreateRepository();
            repo.DeleteVenue(venue.VenueId);
            //repo.DeleteContact(venue.Contact.ContactId);
            return RedirectToAction("ManageVenues", "Admin");
        }
        #endregion

        #region Collaborator Management
        //  manage
        [HttpGet]

        [Authorize(Roles = "Admin")]//TODO: RE-ENABLE FOR DEMO
        public ActionResult ManageCollaborators()
        {
            var repo = RepositoryFactory.CreateRepository();
            var collaborators = repo.GetAllCollaborators();
            return View(collaborators);
        }

        //  add
        [HttpGet]
        [Authorize(Roles = "Admin")]//TODO: RE-ENABLE FOR DEMO
        public ActionResult AddCollaborator()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]//TODO: RE-ENABLE FOR DEMO
        public ActionResult AddCollaborator(CollaboratorViewModel vm, HttpPostedFileBase file)
        {
            var repo = RepositoryFactory.CreateRepository();
            var contact = new ContactInfo
            {
                StreetAddress = vm.StreetAddress,
                City = vm.City,
                State = vm.State,
                Zip = vm.Zip,
                Phone = vm.Phone,
                Email = vm.Email
            };
            var collab = new Collaborator
            {
                Name = vm.Name,
                Description = vm.Description,
                //Website = vm.Website
            };
            collab.ImgPath = UploadImage(file);
            collab.Contact = repo.AddContact(contact);
            repo.AddCollaborator(collab);
            return RedirectToAction("ManageCollaborators", "Admin");
        }
        //  edit
        [HttpGet]
        [Authorize(Roles = "Admin")]//TODO: RE-ENABLE FOR DEMO
        public ActionResult EditCollaborator(int id)
        {
            var repo = RepositoryFactory.CreateRepository();
            var collab = repo.GetCollaboratorById(id);
            var vm = new CollaboratorViewModel(collab);

            return View(vm);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]//TODO: RE-ENABLE FOR DEMO
        public ActionResult EditCollaborator(CollaboratorViewModel vm, HttpPostedFileBase file)
        {
            var repo = RepositoryFactory.CreateRepository();
            var collab = new Collaborator
            {
                CollaboratorId = vm.CollabId,
                Name = vm.Name,
                Description = vm.Description,
                //Website = vm.Website,
                Contact = new ContactInfo
                {
                    ContactId = vm.ContactId,
                    StreetAddress = vm.StreetAddress,
                    City = vm.City,
                    State = vm.State,
                    Zip = vm.Zip,
                    Phone = vm.Phone,
                    Email = vm.Email
                }
            };
            collab.ImgPath = file == null ? vm.ImgPath : UploadImage(file);

            repo.EditContact(collab.Contact);
            repo.EditCollaborator(collab);
            return RedirectToAction("ManageCollaborators", "Admin");
        }
        //  delete
        [HttpGet]
        [Authorize(Roles = "Admin")]//TODO: RE-ENABLE FOR DEMO
        public ActionResult DeleteCollaborator(int id)
        {
            var repo = RepositoryFactory.CreateRepository();
            var collab = repo.GetCollaboratorById(id);
            return View(collab);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]//TODO: RE-ENABLE FOR DEMO
        public ActionResult DeleteCollaborator(Collaborator collab)
        {
            var repo = RepositoryFactory.CreateRepository();
            repo.DeleteCollaborator(collab.CollaboratorId);
            return RedirectToAction("ManageCollaborators", "Admin");
        }
        #endregion

        #region User Management
        //  manage
        [HttpGet]
        [Authorize(Roles = "Admin")]//TODO: REENABLE FOR DEMO
        public ActionResult ManageUsers()
        {
            var repo = RepositoryFactory.CreateRepository();
            var users = repo.GetAllUsers();
            return View(users);
        }
        //  add
        [HttpGet]
        [Authorize(Roles = "Admin")]//TODO: REENABLE FOR DEMO
        public ActionResult AddUser()
        {
            return RedirectToAction("Register", "Account");
        }
        
        //  edit
        [HttpGet]
        [Authorize(Roles = "Admin")]//TODO: REENABLE FOR DEMO
        public ActionResult EditUser(int id)
        {
            var repo = RepositoryFactory.CreateRepository();
            var user = repo.GetUserbyId(id);
            var vm = new RegisterViewModel(user);
            return View(vm);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]//TODO: RE-ENABLE LATER
        public ActionResult EditUser(RegisterViewModel vm, HttpPostedFileBase file)
        {
            var repo = RepositoryFactory.CreateRepository();
            var contact = new ContactInfo
            {
                ContactId = vm.ContactId,
                StreetAddress = vm.StreetAddress,
                City = vm.City,
                State = vm.State,
                Zip = vm.Zip,
                Email = vm.Email,
                Phone = vm.Phone
            };
            var user = new User
            { //TODO: This might be losing the UserId String when it is done!  Make sure this isn't happening
                FirstName = vm.FirstName, LastName = vm.LastName,
                Bio = vm.Bio, AccessLevel = vm.AccessLevel,
                IsEmployee = vm.IsEmployee, JobTitle = vm.JobTitle,
                Username = vm.Username, Id = vm.UserId,
                Contact = contact, UserId = User.Identity.GetUserId()
            };

            if (file != null && file.ContentLength > 0 && !string.IsNullOrEmpty(file.FileName) && file.ContentType.Contains("image"))
            {
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Content/images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    user.ImgPath = path;
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            }

            repo.EditContact(contact);
            repo.EditUser(user);
            return RedirectToAction("ManageUsers", "Admin");
        }
        //  delete
        [HttpGet]
        [Authorize(Roles = "Admin")]//TODO: REENABLE FOR DEMO
        public ActionResult DeleteUser(int id)
        {
            var repo = RepositoryFactory.CreateRepository();
            var user = repo.GetUserbyId(id);
            return View(user);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]//TODO: REENABLE FOR DEMO
        public ActionResult DeleteUser(User user)
        {
            var repo = RepositoryFactory.CreateRepository();
            repo.DeleteUser(user.Id);
            return RedirectToAction("ManageUsers", "Admin");
        }
        #endregion

        #region Contact Form Management
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult ViewQuestions()
        {
            var repo = RepositoryFactory.CreateRepository();
            var questions = repo.GetAllContactForms().Where(m => !m.IsAnswered);

            return View(questions);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult ContactForm(int id)
        {
            var repo = RepositoryFactory.CreateRepository();
            var question = repo.GetContactForm(id);
            return View(question);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult ContactForm(ContactForm contactForm)
        {
            var repo = RepositoryFactory.CreateRepository();
            var form = repo.GetContactForm(contactForm.ContactFormId);
            form.IsAnswered = true;
            repo.EditContactForm(form);
            return RedirectToAction("ViewQuestions", "Admin");
        }
        #endregion

        #region Static Page Management

        public ActionResult ManageStaticPages()
        {
            var repo = RepositoryFactory.CreateRepository();
            var pages = repo.GetAllStaticPages();
            return View(pages);
        }

        [HttpGet]
        public ActionResult AddStaticPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStaticPage(StaticPageViewModel vm)
        {
            var repo = RepositoryFactory.CreateRepository();
            var page = new StaticPage
            {
                Title = vm.Title,
                Body = vm.Body,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            };
            repo.AddStaticPage(page);
            return RedirectToAction("ManageStaticPages", "Admin");
        }

        [HttpGet]
        public ActionResult EditStaticPage(int id)
        {
            var repo = RepositoryFactory.CreateRepository();
            var page = repo.GetStaticPage(id);
            var vm = new StaticPageViewModel(page);
            return View(vm);
        }

        [HttpPost]
        public ActionResult EditStaticPage(StaticPage page)
        {
            var repo = RepositoryFactory.CreateRepository();
            page.DateUpdated = DateTime.Now;
            repo.EditStaticPage(page);
            return RedirectToAction("ManageStaticPages", "Admin");
        }

        [HttpGet]
        public ActionResult DeleteStaticPage(int id)
        {
            var repo = RepositoryFactory.CreateRepository();
            var page = repo.GetStaticPage(id);
            return View(page);
        }

        [HttpPost]
        public ActionResult DeleteStaticPage(StaticPage page)
        {
            var repo = RepositoryFactory.CreateRepository();
            repo.DeleteStaticPage(page.PageId);
            return RedirectToAction("ManageStaticPages", "Admin");
        }
        #endregion


        //FILE UPLOAD

        /// <summary>
        /// Uploads an image to the server
        /// </summary>
        /// <param name="file">The file to be loaded.</param>
        /// <returns>Filepath of uploaded file, or null if the file is null/not an image</returns>
        private string UploadImage(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0 && !string.IsNullOrEmpty(file.FileName) &&
                file.ContentType.Contains("image"))
            {
                try
                {
                    string filename = Path.GetFileName(file.FileName);
                    string path = Path.Combine(Server.MapPath("~/Content/images"), filename);

                    file.SaveAs(path);
                    return $"Content/images/{filename}";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    return null;
                }
            }
            else return null;
        }

        //private List<string> UploadImages(HttpPostedFileBase[] files)
        //{


        //    return null;
        //}
    }
}