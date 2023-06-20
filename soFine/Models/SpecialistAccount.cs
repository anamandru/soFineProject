using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace soFine.Models
{
    public class SpecialistAccount
    {
        public int Id { get; set; }

        [DisplayName("First name")]
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }


        [DisplayName("Current Clinique")]
        [Required(ErrorMessage = "Clinique's name is required")]
        public string CliniqueName { get; set; }


        [DisplayName("Gradueted University")]
        [Required(ErrorMessage = "University's name is required")]
        public string University { get; set; }


        [DisplayName("Diploma number")]
        [Required(ErrorMessage = "Diploma's number is required")]
        public string DiplomaNumber { get; set; }

        public bool Validation { get; set; }
    }
}
