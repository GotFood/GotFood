using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GotFood.Models
{
    public class ProviderPost
    {
        [Key]
        public int ProviderPostID { get; set; }
        [ForeignKey("Provider")]
        public int ProviderID { get; set; }
        [Display(Name = "Date Posted")]
        public DateTime TimeStamp { get; set; }
        [Required]
        [Display(Name = "Please list the food to be donated:")]
        public string FoodType { get; set; }
        [Display(Name = "How many people will the Donation feed?")]
        public string PeopleFed { get; set; }
        [Display(Name = "Are there any potential Allergens?")]
        public string PotentialAllergens { get; set; }
        [Required]
        [Display(Name = "Expiration Date")]
        public DateTime ExpirationDate { get; set; }
        [Required]
        [Display(Name = "Does the Donation require Special Transportation?")]
        public string SpecialTransport { get; set; }
        [Display(Name = "Additional Comments")]
        public string Comments { get; set; }
        
    }
}