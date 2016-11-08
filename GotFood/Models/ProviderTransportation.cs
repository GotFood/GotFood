using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GotFood.Models
{
    public class ProviderTransportation
    {

        [Key]
        public int ID { get; set; }
        [Display(Name = "Able to provide transportation?")]
        public string Trans { get; set; }
        public virtual ICollection<Provider> Provided { get; set; }
    }
}