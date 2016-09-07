using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapstoneV2.Data;
using CapstoneV2.Models.Data;

namespace CapstoneV2.Web.Models
{
    public class BeerViewModel
    {
        public Beer Beer { get; set; }
        public List<SelectListItem> StyleItems { get; set; }
        public List<SelectListItem> SeriesItems { get; set; }
        public List<SelectListItem> CollaboratorItems { get; set; }

        public BeerViewModel()
        {
            StyleItems = new List<SelectListItem>();
            SeriesItems = new List<SelectListItem>();
            CollaboratorItems = new List<SelectListItem>();
        }

        public void SetSelectListItems()
        {
            var repo = new DbRepository();

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
                StyleItems.Add(new SelectListItem
                {
                    Text = s.Name,
                    Value = s.SeriesId.ToString()
                });
            }

            var collabs = repo.GetAllCollaborators();
            foreach (var collab in collabs)
            {
                StyleItems.Add(new SelectListItem
                {
                    Text = collab.Name,
                    Value = collab.CollaboratorId.ToString()
                });
            }
        }
    }
}