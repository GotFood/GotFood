using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GotFood.Models
{
    public class ProviderType
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Provider Type")]
        public string Type { get; set; }
        public virtual ICollection<Provider> Providers { get; set; }
    }
}