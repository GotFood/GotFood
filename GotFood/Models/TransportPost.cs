using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GotFood.Models
{
    public class TransportPost
    {
        [Key]
        public int TransportPostID { get; set; }
        [ForeignKey("Transport")]
        public int TransportID { get; set; }
        public virtual Transport Transport { get; set; }
        [Display(Name = "Date Posted")]
        public DateTime TimeStamp { get; set; }
        [Required]
        [Display(Name = "How are you able to help?")]
        public string Message { get; set; }
        [Required]
        [Display(Name = "Availability: Start Time")]
        public DateTime StartTimeAvailable { get; set; }
        [Required]
        [Display(Name = "Availability: End Time")]
        public DateTime EndTimeAvailable { get; set; }
        [Display(Name = "Additional Comments")]
        public string Comments { get; set; }

        public ICollection<MainFeed> TransportPosts { get; set; }
    }
}