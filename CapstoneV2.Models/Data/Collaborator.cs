using System.Collections.Generic;

namespace CapstoneV2.Models.Data
{
    public class Collaborator
    {
        public int CollaboratorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ContactInfo Contact { get; set; }
        public string ImgPath { get; set; }
        
        
        
        // This property is the URL homepage of a collaborator,
        // which is here so that visitors can view a collaborator's own website
        // from their detail page on our site
        //public string Website { get; set; }
    }
}