using System.Collections.Generic;

namespace CapstoneV2.Models.Data
{
    public class Image
    {
        public int ImgId { get; set; }
        public string ImgPath { get; set; }
        public string Caption { get; set; }
        public List<Tag> Tags { get; set; }
    }
}