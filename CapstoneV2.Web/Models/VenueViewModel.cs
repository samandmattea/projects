using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapstoneV2.Models.Data;

namespace CapstoneV2.Web.Models
{
    public class VenueViewModel
    {
        public int VenueId { get; set; }
        public int ContactId { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Enter a name")]
        public string Name { get; set; }

        [DisplayName("Street Address")]
        [Required(ErrorMessage = "Enter a street address")]
        public string StreetAddress { get; set; }

        [DisplayName("City")]
        [Required(ErrorMessage = "Enter a city")]
        public string City { get; set; }

        [DisplayName("State")]
        [Required(ErrorMessage = "Enter a state")]
        public string State { get; set; }

        [DisplayName("Zip Code")]
        [Required(ErrorMessage = "Enter a zip code")]
        [DataType(DataType.PostalCode)]
        public string Zip { get; set; }

        [DisplayName("Phone")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //TODO: Implement images for venues
        [Display(Name="Venue Picture", Description = "A default image of the venue")]
        public string ImgPath { get; set; }

        public VenueViewModel() { }

        public VenueViewModel(Venue v)
        {
            VenueId = v.VenueId;
            Name = v.Name;
            ContactId = v.Contact.ContactId;
            StreetAddress = v.Contact.StreetAddress;
            City = v.Contact.City;
            State = v.Contact.State;
            Zip = v.Contact.Zip;
            Phone = v.Contact.Phone;
            Email = v.Contact.Email;
            ImgPath = v.ImgPath;
        }
    }
}