using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapstoneV2.Data;
using CapstoneV2.Models.Data;

namespace CapstoneV2.Web.Models
{
    public class NewEventViewModel
    {
        public int EventId { get; set; }

        [DisplayName("Name")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Description")]
        [Required]
        [AllowHtml]
        public string Description { get; set; }

        [Required]
        [Display(Name="Start")]
        [DataType(DataType.DateTime)]
        public DateTime DateStart { get; set; }

        [Required]
        [Display(Name = "End")]
        [DataType(DataType.DateTime)]
        public DateTime DateEnd { get; set; }
        
        //[DisplayName("Start Time")]
        //[DataType(DataType.DateTime)]
        //public DateTime? DateTimeStart { get; set; }

        //[DisplayName("Start Date")]
        //[DataType(DataType.Date)]
        //public DateTime? DateStart { get; set; }

        //[DisplayName("End Time")]
        //[DataType(DataType.DateTime)]
        //public DateTime? DateTimeEnd { get; set; }

        //[DisplayName("End Date")]
        //[DataType(DataType.Date)]
        //public DateTime? DateEnd { get; set; }

        [Display(Name = "Image", Description = "Upload an image for the event")]
        public string ImgPath { get; set; }

        //[DisplayName("Is it an all-day event? ")]
        //public bool IsAllDay { get; set; }

        [DisplayName("Venue")]
        [Required]
        public int? VenueId { get; set; }

        [DisplayName("Name")]
        [Required]
        public string VenueName { get; set; }

        [DisplayName("Street Address")]
        [Required]
        public string VenueStreetAddress { get; set; }

        [DisplayName("City")]
        [Required]
        public string VenueCity { get; set; }

        [DisplayName("State")]
        [Required]
        public string VenueState { get; set; }

        [DisplayName("Zip Code")]
        [DataType(DataType.PostalCode)]
        [Required]
        public string VenueZip { get; set; }

        [DisplayName("Phone")]
        [DataType(DataType.PhoneNumber)]
        public string VenuePhone { get; set; }

        [DisplayName("Email Address")]
        [DataType(DataType.EmailAddress)]
        public string VenueEmail { get; set; }

        public List<SelectListItem> VenueItems { get; set; }

        public NewEventViewModel()
        {
            VenueItems = new List<SelectListItem>();
        }

        public NewEventViewModel(Event e)
        {
            VenueItems = new List<SelectListItem>();
            Name = e.Name;
            Description = e.Description;
            DateStart = e.StartDate;
            DateEnd = e.EndDate;
            VenueId = e.Venue.VenueId;
            ImgPath = e.ImgPath;
        }

        public void SetSelectListItems()
        {
            var repo = RepositoryFactory.CreateRepository();

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