using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InzSklep.Models
{
    public class Producer
    {
        
        public int ProducerId { get; set; }
        [Display(Name = "Producent")]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}