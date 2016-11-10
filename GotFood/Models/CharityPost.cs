using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GotFood.Models
{
    public class CharityPost
    {
        [Key]
        public int CharityPostID { get; set; }
        [ForeignKey("CharityProfile")]
        public int CharityID { get; set; }
        public virtual CharityProfile CharityProfile { get; set; }
        [Display(Name = "Date Posted")]
        public DateTime TimeStamp { get; set; }
        [Required]
        [Display(Name = "What type of food is needed?")]
        public string FoodRequested { get; set; }
        [Display(Name = "Minimum Weight Required?")]
        public double WeightRequested { get; set; }
        [Display(Name = "How many people will be fed?")]
        public int PeopleToFeed { get; set; }
        [Required]
        [Display(Name = "When is the food needed?")]
        public DateTime DateRequested { get; set; }
        [Display(Name = "Additional Comments")]
        public string Comments { get; set; }

        public ICollection<MainFeed> CharityPosts { get; set; }
    }
}