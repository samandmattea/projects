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
    public class NewBeerViewModel
    {
        public int BeerId { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Enter a name for the beer")]
        public string Name { get; set; }

        [DisplayName("ABV")]
        [Required(ErrorMessage = "Enter an ABV")]
        [Range(0,100)]
        public double ABV { get; set; }

        [DisplayName("IBU")]
        public int? IBU { get; set; }

        [DisplayName("Release Date")]
        [Required(ErrorMessage = "Enter a release date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "Enter a description")]
        public string Description { get; set; }

        [DisplayName("Season")]
        public string Season { get; set; }

        [DisplayName("Currently Available?")]
        public bool IsAvailable { get; set; }

        [DisplayName("Flagship Beer?")]
        public bool IsFlagship { get; set; }

        public double? UntappdRating { get; set; }

        [Display(Name="Image",Description = "The default image for this beer")]
        //[DisplayName("Link to an image")]
        //[DataType(DataType.ImageUrl)]
        public string ImgPath { get; set; }

        // for existing style dropdown
        [DisplayName("Style")]
        [Required]
        public int? StyleId { get; set; }
        // for new style form
        [DisplayName("Name")]
        [Required]
        public string StyleName { get; set; }
        [DisplayName("Description")]
        [Required]
        public string StyleDescription { get; set; }

        // for existing series dropdown
        [DisplayName("Series")]
        public int? SeriesId { get; set; }
        // for new series form
        [DisplayName("Name")]
        [Required]
        public string SeriesName { get; set; }
        [DisplayName("Description")]
        [Required]
        public string SeriesDescription { get; set; }
        
        // for existing collab dropdown
        [DisplayName("Collaborator")]
        
        public int? CollabId { get; set; }
        // for new collab form
        [DisplayName("Name")]
        [Required]
        public string CollabName { get; set; }
        [DisplayName("Description")]
        [Required]
        public string CollabDescription { get; set; }
        [DisplayName("Street Address")]
        [Required]
        public string CollabStreetAddress { get; set; }
        [DisplayName("City")]
        [Required]
        public string CollabCity { get; set; }
        [DisplayName("State")]
        [Required]
        public string CollabState { get; set; }
        [DisplayName("Zip Code")]
        [Required]
        [DataType(DataType.PostalCode)]
        public string CollabZip { get; set; }
        [DisplayName("Website")]
        [DataType(DataType.Url)]
        public string CollabWebsite { get; set; }

        public List<SelectListItem> StyleItems { get; set; }
        public List<SelectListItem> SeriesItems { get; set; }
        public List<SelectListItem> CollaboratorItems { get; set; }

        public NewBeerViewModel()
        {
            StyleItems = new List<SelectListItem>();
            SeriesItems = new List<SelectListItem>();
            CollaboratorItems = new List<SelectListItem>();
        }

        /// <summary>
        /// Populates fields from a pre-existing beer, for EDIT methods
        /// </summary>
        /// <param name="beer">Beer to be edited</param>
        public NewBeerViewModel(Beer beer)
        {
            StyleItems = new List<SelectListItem>();
            SeriesItems = new List<SelectListItem>();
            CollaboratorItems = new List<SelectListItem>();
            BeerId = beer.BeerId;
            Name = beer.Name;
            Description = beer.Description;
            ABV = beer.ABV;
            IBU = beer.IBU;
            Season = beer.Season;
            //Img = beer.Img;
            IsAvailable = beer.IsAvailable;
            IsFlagship = beer.IsFlagship;
            StyleId = beer.Style.StyleId;
            ReleaseDate = beer.ReleaseDate;
            if (beer.Series != null)
                SeriesId = beer.Series.SeriesId;
            if (beer.Collaborator != null)
                CollabId = beer.Collaborator.CollaboratorId;
        }

        public void SetSelectListItems()
        {
            var repo = RepositoryFactory.CreateRepository();

            var styles = repo.GetAllStyles();
            foreach (var style in styles)
            {
                StyleItems.Add(new SelectListItem
                {
                    Text = style.Name,
                    Value = style.StyleId.ToString()
                });
            }

            var series = repo.GetAllSeries();
            foreach (var s in series)
            {
                SeriesItems.Add(new SelectListItem
                {
                    Text = s.Name,
                    Value = s.SeriesId.ToString()
                });
            }

            var collabs = repo.GetAllCollaborators();
            foreach (var collab in collabs)
            {
                CollaboratorItems.Add(new SelectListItem
                {
                    Text = collab.Name,
                    Value = collab.CollaboratorId.ToString()
                });
            }
        }
    }
}