using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GotFood.Models
{
    public class Provider
    {
        [Key]
        public int ProviderID { get; set; }
        [Display(Name = "Name of Organization")]
        public string OrgName { get; set; }
        [Display(Name = "Contact Name")]
        public string ContactName { get; set; }
        [Display(Name = "Email address")]
        [Required]
        [EmailAddress(ErrorMessage = "The email format is not valid")]
        public string ContactEmail { get; set; }
        [Display(Name = "Preferred Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4}).*$", ErrorMessage = "Not a valid Phone number")]
        public string ContactPhone { get; set; }
        [Display(Name = "Street Number")]
        public string StreetNumber { get; set; }
        [Display(Name = "Street Name")]
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        public string Website { get; set; }
        [Display(Name = "Foods Generally Available: ")]
        public string Foods { get; set; }


        [ForeignKey("ProviderType")]
        [Display(Name = "Provider Type")]
        public int TypeID { get; set; }
        public virtual ProviderType ProviderType { get; set; }


        [ForeignKey("ProviderTransportation")]
        [Display(Name = "Transportation?")]
        public int TranspoID { get; set; }
        public virtual ProviderTransportation ProviderTransportation { get; set; }

        //[ForeignKey("ApplicationUser")]
        //public string Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        //public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }

}