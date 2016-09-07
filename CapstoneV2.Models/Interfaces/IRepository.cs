using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapstoneV2.Models.Data;

namespace CapstoneV2.Models.Interfaces
{
    public interface IRepository
    {
        List<Beer> GetAllBeers();

        Beer GetBeerById(int id);

        void AddBeer(Beer beer);

        void EditBeer(Beer beer);

        void DeleteBeer(int id);
        
        IEnumerable<BlogEntry> GetAllBlogEntries();

        BlogEntry GetBlogEntryById(int id);

        void AddBlogEntry(BlogEntry blog);

        void EditBlogEntry(BlogEntry blog);

        void DeleteBlogEntry(int id);

        List<Collaborator> GetAllCollaborators();

        Collaborator GetCollaboratorById(int id);

        Collaborator AddCollaborator(Collaborator collab);

        void EditCollaborator(Collaborator collab);

        void DeleteCollaborator(int id);

        List<ContactInfo> GetAllContacts();

        ContactInfo GetContactById(int id);

        ContactInfo AddContact(ContactInfo contact);

        void EditContact(ContactInfo contact);

        void DeleteContact(int id);

        List<Event> GetAllEvents();

        Event GetEventById(int id);

        void AddEvent(Event e);

        void EditEvent(Event e);

        void DeleteEvent(int id);

        List<Series> GetAllSeries();

        Series GetSeriesById(int id);

        Series AddSeries(Series series);

        void EditSeries(Series series);

        void DeleteSeries(int id);

        List<User> GetAllUsers();

        User GetUserbyId(int id);

        User GetUserbyId(string id);

        void AddUser(User user);

        void EditUser(User user);

        void DeleteUser(int id);

        List<Venue> GetAllVenues();

        Venue GetVenueById(int id);

        Venue AddVenue(Venue venue);

        void EditVenue(Venue venue);

        void DeleteVenue(int id);
        
        List<Style> GetAllStyles();

        Style GetStyleById(int id);

        Style AddStyle(Style style);

        void EditStyle(Style style);

        void DeleteStyle(int id);

        List<Tag> GetAllTags();

        void AddTag(Tag tag);

        void DeleteTag(int id);

        List<User> GetAllEmployees();

        List<ContactForm> GetAllContactForms();

        ContactForm GetContactForm(int id);

        void AddContactForm(ContactForm form);

        void EditContactForm(ContactForm form);

        List<StaticPage> GetAllStaticPages();

        StaticPage GetStaticPage(int id);

        void AddStaticPage(StaticPage page);

        void EditStaticPage(StaticPage page);

        void DeleteStaticPage(int id);

        User GetUserbyAspId(string id);

        void AddUserRole(int userId, int roleId);
    }
}
