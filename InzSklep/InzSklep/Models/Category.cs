using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InzSklep.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Display(Name = "Kategoria")]
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Zdjęcie")]
        [Required]
        public string IconFileName { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}