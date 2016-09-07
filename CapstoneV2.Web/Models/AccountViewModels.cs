using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using CapstoneV2.Models.Data;
using CapstoneV2.Models.Enums;

namespace CapstoneV2.Web.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        //[EmailAddress]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        public int ContactId { get; set; }

        public int ImageId { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "User ID")]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Required]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        //[Required]
        [Display(Name="Bio", Description="Tell us a little bit about yourself")]
        public string Bio { get; set; }

        [Display(Name = "Are they a brewery employee?")]
        public bool IsEmployee { get; set; }

        [Display(Name="Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name="Street Address")]
        public string StreetAddress { get; set; }

        [Display(Name="City")]
        public string City { get; set; }

        [Display(Name="State")]
        public string State { get; set; }

        [Display(Name="Zip Code")]
        [DataType(DataType.PostalCode)]
        public string Zip { get; set; }

        [Required]
        [Display(Name="Access Level")]
        [EnumDataType(typeof(AccessLevel))]
        public AccessLevel AccessLevel { get; set; }

        [Display(Name = "Image Link", Description = "Insert a link to an image of yourself")]
        //[DataType(DataType.ImageUrl)]
        public string ImgPath { get; set; }


        ////TODO: Implement profile image uploads for users
        //[Display(Name="Profile Picture", Description = "A photo of you to display next to your posts")]
        //[DataType(DataType.Upload)]
        //public HttpPostedFileBase File { get; set; }

        public RegisterViewModel() { }

        public RegisterViewModel(User u)
        {
            UserId = u.Id;
            Username = u.Username;
            FirstName = u.FirstName;
            LastName = u.LastName;
            Bio = u.Bio;
            JobTitle = u.JobTitle;
            //Img = u.Img;
            AccessLevel = u.AccessLevel;
            IsEmployee = u.IsEmployee;
            ContactId = u.Contact.ContactId;
            StreetAddress = u.Contact.StreetAddress;
            City = u.Contact.City;
            State = u.Contact.State;
            Zip = u.Contact.Zip;
            Phone = u.Contact.Phone;
            Email = u.Contact.Email;
            ImgPath = u.ImgPath;
        }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
