using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GotFood.Models
{
    public class Transport
    {
        [Key]
        public int TransportID { get; set; }
        [Display(Name = "Organization Name")]
        public string OrganizationName { get; set;}
        [Display(Name = "Contact Person")]
        [Required]
        public string ContactName { get; set; }
        [Display(Name = "Position of Contact Person")]
        public string ContactPosition { get; set; }
        [Display(Name = "Phone Number")]
        [Required]
        [PhoneAttribute(ErrorMessage = "This is not a valid phone number.")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4}).*$", ErrorMessage = "Not a valid Phone number")]
        public string ContactPhone { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "The email format is not valid")]
        public string ContactEmail { get; set; }
        [Display(Name = "Additional Contact Information")]
        public string AdditionalContactInfo { get; set; }

        [Display(Name = "Street Number")]
        public string StreetNumber { get; set; }
        [Display(Name = "Street Name")]
        public string StreetName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Zip { get; set; }
        [Required]
        [Display(Name = "Types of Transportation Offered")]
        public string TransportationTypes { get; set; }
        [Required]
        [Display(Name = "Types of Food that can be Transported")]
        public string FoodTypes { get; set; }
        [Display(Name = "General Availability")]
        public string GeneralAvailability { get; set; }
        public string Website { get; set; }
    }
}