using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapstoneV2.Models.Data;
using CapstoneV2.Models.Enums;
using CapstoneV2.Models.Interfaces;

namespace CapstoneV2.Data
{
    public class InMemoryRepository : IRepository
    {
        public List<Beer> Beers { get; set; }
        public List<BlogEntry> BlogEntries { get; set; }
        public List<Series> Series { get; set; }
        public List<Style> Styles { get; set; }
        public List<User> Users { get; set; }
        public List<Venue> Venues { get; set; }
        public List<Event> Events { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Collaborator> Collaborators { get; set; }
        public List<ContactInfo> Contacts { get; set; }
        public List<ContactForm> ContactForms { get; set; }
        public List<StaticPage> StaticPages { get; set; }

        public InMemoryRepository()
        {
            Beers = new List<Beer>()
            {
                #region Beer Repo Instantiation
                new Beer()
                {
                    BeerId = 1,
                    ABV = 4.5,
                    Collaborator = new Collaborator(),
                    Description = "First Beer",
                    //ImgPath = "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcTEqykNy1UIElyK7YzlKmqGw3HZaZwqYZlQ91OLGXjvhiiD29n2",
                    IsAvailable = true,
                    IsFlagship = true,
                    Name = "Beer 1",
                    ReleaseDate = DateTime.Parse("1/1/2016"),
                    Style = new Style()
                    {
                        StyleId = 1,
                        Description = "This is the first Style",
                        Name = "Style One"
                    }
                },
                new Beer()
                {
                    BeerId = 2,
                    ABV = 4.5,
                    Collaborator = new Collaborator(),
                    Description = "First Beer",
                    //ImgPath = "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcTEqykNy1UIElyK7YzlKmqGw3HZaZwqYZlQ91OLGXjvhiiD29n2",
                    IsAvailable = false,
                    IsFlagship = false,
                    Name = "Beer 2",
                    ReleaseDate = DateTime.Parse("1/1/2016"),
                    Style = new Style()
                    {
                        StyleId = 2,
                        Description = "This is the second Style",
                        Name = "Style Two"
                    }
                }
                #endregion
            };

            BlogEntries = new List<BlogEntry>
            {
                #region Blog Repo Instantiation
                new BlogEntry
                {
                    Title = "Test Post #1",
                    Body = @"<p>This is a test post</p><h4>It uses markup</h4><p>to test how tinymce will work</p>",
                    DatePosted = DateTime.Today,
                    User = new User{FirstName = "User", LastName = "Number One", JobTitle = "Tester"},
                    IsApproved = true,
                    DateExpire = null,
                    Beer = null,
                    EntryId = 1,
                    Event = null,
                    //Images = null,
                    Tags = new List<Tag>
                    {
                        new Tag { TagId = 1, Name = "Test1" },
                        new Tag { TagId = 2, Name = "Test2" }
                    }
                },
                new BlogEntry
                {
                    Title = "Test Post #2",
                    Body = @"<p>This is another test post</p><b>It uses markup</b><p>to test how tinymce will work</p>",
                    DatePosted = new DateTime(2016, 8, 1),
                    User = new User{FirstName = "User", LastName = "Number Two", JobTitle = "Developer"},
                    IsApproved = true,
                    DateExpire = DateTime.Parse("12/12/2015"),
                    Beer = null,
                    EntryId = 2,
                    Event = null,
                    //Images = null,
                    Tags = new List<Tag>
                    {
                        new Tag { TagId = 2, Name = "Test2" },
                        new Tag { TagId = 3, Name = "Test3" }
                    }
                },
                new BlogEntry
                {
                    Title = "Test Post #3",
                    Body = @"<p>This is yet another test post</p><em>It uses markup</em><p>to test how tinymce will work</p>",
                    DatePosted = new DateTime(2016, 7, 4),
                    User = new User{FirstName = "User", LastName = "Number One", JobTitle = "Tester"},
                    IsApproved = true,
                    DateExpire = DateTime.Parse("12/12/2017"),
                    Beer = null,
                    EntryId = 3,
                    Event = null,
                    //Images = null,
                    Tags = new List<Tag>
                    {
                        new Tag { TagId = 1, Name = "Test1" },
                        new Tag { TagId = 3, Name = "Test3" }
                    }
                },

                new BlogEntry()
                {
                    Title = "Test Post #4",
                    Body = @"<p>This is yet another test post</p><em>It uses markup</em><p>to test how tinymce will work</p>",
                    DatePosted = new DateTime(2016, 7, 4),
                    User = new User{FirstName = "User", LastName = "Number One", JobTitle = "Tester"},
                    IsApproved = false,
                    DateExpire = null,
                    Beer = null,
                    EntryId = 3,
                    Event = null,
                    //Images = null,
                    Tags = new List<Tag>
                    {
                        new Tag { TagId = 1, Name = "Test1" },
                        new Tag { TagId = 3, Name = "Test3" }
                    }
                }
                #endregion
            };

            Styles = new List<Style>();

            Series = new List<Series>();

            Users = new List<User>
            {
                #region User Repo Instantiation
                new User
                {
                    AccessLevel = AccessLevel.Admin,
                    FirstName = "John",
                    LastName = "Kachurek",
                    JobTitle = "Web Developer",
                    Id = 1,
                    //ImgPath = "https://hd.unsplash.com/photo-1420578509940-73e9f7232eae",
                    IsEmployee = true
                },
                new User
                {
                    AccessLevel = AccessLevel.Admin,
                    FirstName = "Sam",
                    LastName = "DelBrocco",
                    JobTitle = "Bartender",
                    Id = 2,
                    //ImgPath = "https://hd.unsplash.com/reserve/sozGYg0tQdSmsUkoPhvt_12.jpg",
                    IsEmployee = true
                },
                new User
                {
                    AccessLevel = AccessLevel.Admin,
                    FirstName = "Chris",
                    LastName = "Mason",
                    JobTitle = "Brewer",
                    Id = 3,
                    //ImgPath = "https://hd.unsplash.com/photo-1414604582943-2fd913b3cb17",
                    IsEmployee = true
                },
                new User
                {
                    AccessLevel = AccessLevel.Admin,
                    FirstName = "Mattea",
                    LastName = "Azara",
                    JobTitle = "Brewer",
                    Id = 4,
                    //ImgPath = "https://hd.unsplash.com/photo-1445404590072-16ef9c18bd83",
                    IsEmployee = true
                }
                #endregion
            };

            Venues = new List<Venue>();

            Events = new List<Event>
            {
                #region Event Repo Instantiation
                new Event
                {
                    Name = "Beerfest MMXVII",
                    Description = "Slammin' beers with bros from sunup to sundown, like real Americans.",
                    StartDate = new DateTime(2017, 7, 4, 16, 0, 0),
                    EndDate = new DateTime(2017, 7, 4, 23, 30, 0),
                    Venue = new Venue
                    {
                        Name = "The White House",
                        Contact = new ContactInfo
                        {
                            StreetAddress = "1600 Pennsylvania Ave NW",
                            City = "Washington DC",
                            State = "DC"
                        }
                    },
                }
                #endregion
            };

            Tags = new List<Tag>
            {
                new Tag { TagId = 1, Name = "Test1" },
                new Tag { TagId = 2, Name = "Test2" },
                new Tag { TagId = 3, Name = "Test3" }
            };

            ContactForms = new List<ContactForm>();
            StaticPages = new List<StaticPage> {_faq};
            Contacts = new List<ContactInfo>();
            Collaborators = new List<Collaborator>();
        }

        #region FAQ Static Page

        private readonly StaticPage _faq = new StaticPage
        {
            PageId = 1,
            Title = "FAQ",
            Body = "<h4>Can I bring my dog to the brewery?</h4>" +
                   "<p>Yes! Since we do not serve food, dogs are welcome.</p>" +
                   "<h4>Are minors allowed in the brewery?</h4>" +
                   "<p>As long as they are accompanied by an adult, minors can be at the brewery.</p>"
        };

        #endregion

        #region Beers
        public List<Beer> GetAllBeers() { return Beers; }

        public Beer GetBeerById(int id)
        {
            return Beers.FirstOrDefault(b => b.BeerId == id);
        }

        public void AddBeer(Beer beer)
        {
            beer.BeerId = Beers.Any() ? Beers.Max(b => b.BeerId) + 1 : 1;
            Beers.Add(beer);
        }

        public void EditBeer(Beer beer)
        {
            DeleteBeer(beer.BeerId);
            AddBeer(beer);
        }

        public void DeleteBeer(int id)
        {
            Beers.RemoveAll(b => b.BeerId == id);
        }
        #endregion

        #region Blog
        public IEnumerable<BlogEntry> GetAllBlogEntries()
        {
            return BlogEntries;
        }

        public BlogEntry GetBlogEntryById(int id)
        {
            return BlogEntries.FirstOrDefault(b => b.EntryId == id);
        }

        public void AddBlogEntry(BlogEntry blog)
        {
            blog.EntryId = BlogEntries.Any() ? BlogEntries.Max(b => b.EntryId) + 1 : 1;
            BlogEntries.Add(blog);
        }

        public void EditBlogEntry(BlogEntry blog)
        {
            DeleteBlogEntry(blog.EntryId);
            AddBlogEntry(blog);
        }

        public void DeleteBlogEntry(int id)
        {
            BlogEntries.RemoveAll(b => b.EntryId == id);
        }
        #endregion

        #region Collaborators
        public List<Collaborator> GetAllCollaborators()
        {
            return Collaborators;
        }

        public Collaborator GetCollaboratorById(int id)
        {
            return Collaborators.FirstOrDefault(m => m.CollaboratorId == id);
        }

        public Collaborator AddCollaborator(Collaborator collab)
        {
            collab.CollaboratorId = Collaborators.Any() ? Collaborators.Max(c => c.CollaboratorId) + 1 : 1;
            Collaborators.Add(collab);

            return collab;
        }

        public void EditCollaborator(Collaborator collab)
        {
            DeleteCollaborator(collab.CollaboratorId);
            AddCollaborator(collab);
        }

        public void DeleteCollaborator(int id)
        {
            Collaborators.RemoveAll(m => m.CollaboratorId == id);
        }
        #endregion

        #region Contacts
        public List<ContactInfo> GetAllContacts()
        {
            return Contacts;
        }

        public ContactInfo GetContactById(int id)
        {
            return Contacts.FirstOrDefault(m => m.ContactId == id);
        }

        public ContactInfo AddContact(ContactInfo contact)
        {
            contact.ContactId = Contacts.Any() ? Contacts.Max(c => c.ContactId) + 1 : 1;
            Contacts.Add(contact);
            return contact;
        }

        public void EditContact(ContactInfo contact)
        {
            DeleteContact(contact.ContactId);
            AddContact(contact);
        }

        public void DeleteContact(int id)
        {
            Contacts.RemoveAll(m => m.ContactId == id);
        }
        #endregion

        #region Events
        public List<Event> GetAllEvents()
        {
            return Events;
        }

        public Event GetEventById(int id)
        {
            return Events.FirstOrDefault(e => e.EventId == id);
        }

        public void AddEvent(Event e)
        {
            e.EventId = Events.Any() ? Events.Max(m => m.EventId) + 1 : 1;
            Events.Add(e);
        }

        public void EditEvent(Event e)
        {
            DeleteEvent(e.EventId);
            AddEvent(e);
        }

        public void DeleteEvent(int id)
        {
            Events.RemoveAll(e => e.EventId == id);
        }
        #endregion

        #region Series
        public List<Series> GetAllSeries()
        {
            return Series;
        }

        public Series GetSeriesById(int id)
        {
            return Series.FirstOrDefault(s => s.SeriesId == id);
        }

        public Series AddSeries(Series series)
        {
            series.SeriesId = Series.Any() ? Series.Max(s => s.SeriesId) + 1 : 1;
            Series.Add(series);

            return series;
        }

        public void EditSeries(Series series)
        {
            DeleteSeries(series.SeriesId);
            AddSeries(series);
        }

        public void DeleteSeries(int id)
        {
            Series.RemoveAll(s => s.SeriesId == id);
        }
        #endregion

        #region Users
        public List<User> GetAllUsers()
        {
            return Users;
        }

        public List<User> GetAllEmployees()
        {
            return Users.Where(x => x.IsEmployee).ToList();
        }

        public User GetUserbyId(int id)
        {
            return Users.FirstOrDefault(u => u.Id == id);
        }

        public User GetUserbyId(string id)
        {
            return Users.FirstOrDefault(u => u.UserId == id);
        }

        public User GetUserbyAspId(string id)
        {
            throw new NotImplementedException();
        }

        public void AddUserRole(int userId, int roleId)
        {
            throw new NotImplementedException();
        }

        public void AddUser(User user)
        {
            user.Id = Users.Any() ? Users.Max(u => u.Id) + 1 : 1;
            Users.Add(user);
        }

        public void EditUser(User user)
        {
            DeleteUser(user.Id);
            AddUser(user);
        }

        public void DeleteUser(int id)
        {
            Users.RemoveAll(u => u.Id == id);
        }
        #endregion

        #region Venues
        public List<Venue> GetAllVenues()
        {
            return Venues;
        }

        public Venue GetVenueById(int id)
        {
            return Venues.FirstOrDefault(v => v.VenueId == id);
        }

        public Venue AddVenue(Venue venue)
        {
            venue.VenueId = Venues.Any() ? Venues.Max(v => v.VenueId) + 1 : 1;
            Venues.Add(venue);
            return venue;
        }

        public void EditVenue(Venue venue)
        {
            DeleteVenue(venue.VenueId);
            AddVenue(venue);
        }

        public void DeleteVenue(int id)
        {
            Venues.RemoveAll(v => v.VenueId == id);
        }
        #endregion

        #region Styles
        public List<Style> GetAllStyles()
        {
            return Styles;
        }

        public Style GetStyleById(int id)
        {
            return Styles.FirstOrDefault(s => s.StyleId ==  id);
        }

        public Style AddStyle(Style style)
        {
            style.StyleId = Styles.Any() ? Styles.Max(s => s.StyleId) + 1 : 1;
            Styles.Add(style);

            return style;
        }

        public void EditStyle(Style style)
        {
            DeleteStyle(style.StyleId);
            AddStyle(style);
        }

        public void DeleteStyle(int id)
        {
            Styles.RemoveAll(s => s.StyleId == id);
        }
        #endregion

        #region Tags
        public List<Tag> GetAllTags()
        {
            return Tags;
        }

        public void AddTag(Tag tag)
        {
            tag.TagId = Tags.Any() ? Tags.Max(t => t.TagId) + 1 : 1;
            Tags.Add(tag);
        }

        public void DeleteTag(int id)
        {
            Tags.RemoveAll(t => t.TagId == id);
        }
        #endregion

        #region Contact Forms
        public List<ContactForm> GetAllContactForms()
        {
            return ContactForms;
        }

        public ContactForm GetContactForm(int id)
        {
            return ContactForms.FirstOrDefault(c => c.ContactFormId == id);
        }

        public void AddContactForm(ContactForm form)
        {
            form.ContactFormId = ContactForms.Any() ? ContactForms.Max(c => c.ContactFormId) + 1 : 1;
            ContactForms.Add(form);
        }

        public void EditContactForm(ContactForm form)
        {
            DeleteContactForm(form.ContactFormId);
            AddContactForm(form);
        }

        public void DeleteContactForm(int id)
        {
            ContactForms.RemoveAll(c => c.ContactFormId == id);
        }
        #endregion

        #region Static Pages
        public List<StaticPage> GetAllStaticPages()
        {
            return StaticPages;
        }

        public StaticPage GetStaticPage(int id)
        {
            return StaticPages.FirstOrDefault(p => p.PageId == id);
        }

        public void AddStaticPage(StaticPage page)
        {
            page.PageId = StaticPages.Any() ? StaticPages.Max(p => p.PageId) + 1 : 1;
            StaticPages.Add(page);
        }

        public void EditStaticPage(StaticPage page)
        {
            DeleteStaticPage(page.PageId);
            AddStaticPage(page);
        }

        public void DeleteStaticPage(int id)
        {
            StaticPages.RemoveAll(p => p.PageId == id);
        }
        #endregion


    }
}
