using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CapstoneV2.Models.Data;

namespace CapstoneV2.Web.Models
{
    public class CollaboratorViewModel
    {
        public int CollabId { get; set; }
        public int ContactId { get; set; }

        [DisplayName("Name")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Description")]
        [Required]
        public string Description { get; set; }

        [DisplayName("Street Address")]
        [Required]
        public string StreetAddress { get; set; }

        [DisplayName("City")]
        [Required]
        public string City { get; set; }

        [DisplayName("State")]
        [Required]
        public string State { get; set; }

        [DisplayName("Zip Code")]
        [Required]
        [DataType(DataType.PostalCode)]
        public string Zip { get; set; }

        [DisplayName("Phone")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DisplayName("Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name="Image")]
        public string ImgPath { get; set; }

        //TODO: ADD COLLAB WEBSITES
        //[DisplayName("Website")]
        //[DataType(DataType.Url)]
        //public string Website { get; set; }

        public CollaboratorViewModel() { }

        /// <summary>
        /// Builds a collab view model with an existing collaborator for editing
        /// </summary>
        /// <param name="collab"></param>
        public CollaboratorViewModel(Collaborator collab)
        {
            CollabId = collab.CollaboratorId;
            Name = collab.Name;
            Description = collab.Description;
            StreetAddress = collab.Contact.StreetAddress;
            City = collab.Contact.City;
            State = collab.Contact.State;
            Zip = collab.Contact.Zip;
            Phone = collab.Contact.Phone;
            Email = collab.Contact.Email;
            ContactId = collab.Contact.ContactId;
            //Website = collab.Website;
        }
    }
}