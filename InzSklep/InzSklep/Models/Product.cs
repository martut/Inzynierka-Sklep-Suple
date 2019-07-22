using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InzSklep.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        [Display(Name = "Produkt")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Display(Name = "Krótki Opis")]
        [MaxLength(298,ErrorMessage =  "Maksymalna ilość znaków to 298")]
        public string ShortDescription { get; set; }
        [Display(Name = "Producent")]
        public int ProducerId { get; set; }
        [Display(Name = "Data Dodania")]
        public DateTime AddedDate { get; set; }
        [Display(Name = "Zdjęcie")]
        public string ProductFileName { get; set; }
        [Display(Name = "Cena")]
        [Required]
        public decimal Price { get; set; }
        [Display(Name = "Ilość")]
        public int ProductQuantity { get; set; }
        public bool IsHidden { get; set; }
        [Display(Name = "BestSeller")]
        public bool IsBestSeller { get; set; }
        [Display(Name = "Hot")]
        public bool IsHot { get; set; }





        public virtual Category Category { get; set; }

        public virtual Producer Producer { get; set; }

    }
}