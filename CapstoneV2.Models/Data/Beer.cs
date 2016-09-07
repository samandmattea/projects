using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneV2.Models.Data
{
    public class Beer
    {
        public int BeerId { get; set; }
        public string Name { get; set; }
        public double ABV { get; set; }
        public int? IBU { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public string Season { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsFlagship { get; set; }
        public double? UntappdRating { get; set; }
        public string ImgPath { get; set; }
        public Series Series { get; set; }
        public Style Style { get; set; }
        public Collaborator Collaborator { get; set; }
    }
}
