﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InzSklep.Models
{
    public class UserData
    {
        [Key]
        public string UserDataId { get; set; }

        [Display(Name = "Imię")]
        [Required(ErrorMessage = "Musisz wprowadzić imię")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Display(Name = "Nazwisko")]
        [Required(ErrorMessage = "Musisz wprowadzić nazwisko")]
        [StringLength(150)]
        public string LastName { get; set; }

        [Display(Name = "Adres")]
        [Required(ErrorMessage = "Wprowadź adres")]
        [StringLength(150)]
        public string Address { get; set; }

        [Display(Name = "Miasto")]
        [Required(ErrorMessage = "Wprowadź miasto")]
        [StringLength(50)]
        public string City { get; set; }

        [Display(Name = "Kod Pocztowy")]
        [Required(ErrorMessage = "Wprowadź kod pocztowy w formacie: __*___")]
        [StringLength(6)]
        [RegularExpression(@"^\d{2}-\d{3}$")]
        public string ZipCode { get; set; }

        [Display(Name = "Numer Telefonu")]
        [Required(ErrorMessage = "Wprowadź numer telefonu")]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Wprowadź adres Email")]
        [EmailAddress(ErrorMessage = "Błędny format adresu Email")]
        public string Email { get; set; }


    }
}