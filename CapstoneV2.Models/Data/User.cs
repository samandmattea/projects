using CapstoneV2.Models.Enums;

namespace CapstoneV2.Models.Data
{
    public class User
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string JobTitle { get; set; }
        public AccessLevel AccessLevel { get; set; }
        public ContactInfo Contact { get; set; }
        public string ImgPath { get; set; }
        public string Bio { get; set; }
        public bool IsEmployee { get; set; }
    }
}