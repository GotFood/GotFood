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
        [Display(Name = "Date Posted")]
        public DateTime TimeStamp { get; set; }
        [Required]
        [Display(Name = "How are you able to help?")]
        public string Message { get; set; }
        [Required]
        [Display(Name = "Date Available")]
        public DateTime DateAvailable { get; set; }
        [Display(Name = "Additional Comments")]
        public string Comments { get; set; }
    }
}