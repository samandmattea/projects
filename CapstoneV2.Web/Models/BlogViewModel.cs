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
    public class BlogViewModel
    {
        public int BlogId { get; set; }

        [DisplayName("Title")]
        [Required(ErrorMessage = "Enter a title")]
        public string Title { get; set; }

        [DisplayName("Body")]
        [Required(ErrorMessage = "Enter content for your post")]
        [AllowHtml]
        public string Body { get; set; }

        [Display(Name =  "Expiration Date", Description = "Optional. After this date, the post will be archived.")]
        [DataType(DataType.Date)]
        public DateTime? ExpireDate { get; set; }

        public DateTime PostDate { get; set; }

        [Display(Name = "Tags", Description = "Enter a list of tags that will make this post easy to find.")]
        public string TagInput { get; set; }

        [DisplayName("Image")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase File { get; set; }

        [DisplayName("Caption")]
        public string ImgCaption { get; set; }

        public List<HttpPostedFileBase> ImageFiles { get; set; }

        public DateTime DateUpdated { get; set; }
        
        public List<SelectListItem> EventItems { get; set; }
        public List<SelectListItem> BeerItems { get; set; }
        public List<Tag> Tags { get; set; }

        public BlogViewModel()
        {
            EventItems = new List<SelectListItem>();
            BeerItems = new List<SelectListItem>();
        }

        public BlogViewModel(BlogEntry blog)
        {
            EventItems = new List<SelectListItem>();
            BeerItems = new List<SelectListItem>();
            Tags = new List<Tag>();

            BlogId = blog.EntryId;
            Title = blog.Title;
            Body = blog.Body;
            Tags = blog.Tags;
            if (blog.DateExpire.HasValue)
                ExpireDate = blog.DateExpire.Value;
            PostDate = blog.DatePosted;
        }

        public void SetSelectListItems()
        {
            var repo = new DbRepository();

            var events = repo.GetAllEvents();
            foreach (var e in events)
            {
                EventItems.Add(new SelectListItem
                {
                    Text = e.Name,
                    Value = e.EventId.ToString()
                });
            }

            var beers = repo.GetAllBeers();
            foreach (var beer in beers)
            {
                BeerItems.Add(new SelectListItem
                {
                    Text = beer.Name,
                    Value = beer.BeerId.ToString()
                });
            }
        }
    }
}