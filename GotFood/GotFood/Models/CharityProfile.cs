﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GotFood.Models
{
    public class CharityProfile
    {

        [Key]
        public int CharityID { get; set; }
        [Display(Name ="Charity Name")]
        [Required]
        public string CharityName { get; set; }
        [Display(Name ="Street Number")]
        public string StreetNumber { get; set; }
        [Display(Name ="Street Name")]
        public string StreetName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Zip { get; set; }
        [Display(Name ="Brief Description of Your Charity")]
        public string MissionStatement { get; set; }
        [Display(Name ="Contact Person")]
        public string ContactName { get; set; }
        [Display(Name ="Position of Contact Person")]
        public string ContactPosition { get; set; }
        [Display(Name ="Phone Number")]
        [Required]
        public string ContactPhone { get; set; }
        [Required]
        [Display(Name ="Email")]
        public string ContactEmail { get; set; }
        [Display(Name ="Additional Contact Information")]
        public string AdditionalContactInfo { get; set; }
        [Display(Name ="Food Commonly Needed")]
        public string GenFoodRequest { get; set; }
        [Display(Name ="501 3C Number")]
        [Required]
        public string CharityNum { get; set; }
        public string Website { get; set; }
        


    }
}