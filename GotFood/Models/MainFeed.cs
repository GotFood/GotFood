using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GotFood.Models
{
    public class MainFeed
    {
        [Key]
        public int MainFeedID { get; set; }

        public int ProviderPostID { get; set; }
        public ProviderPost ProviderPost { get; set; }

        public int CharityPostID { get; set; }
        public CharityPost CharityPost { get; set; }

        public int TransportPostID { get; set; }
        public TransportPost TransportPost { get; set; }
    }
}