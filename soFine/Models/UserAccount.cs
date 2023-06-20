using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace soFine.Models
{
    public class UserAccount
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

        [DisplayName("Skin type")]
        public string SkinType { get; set; }
        [DisplayName("Hair type")]
        public string HairType { get; set; }

        public SkinQuiz SkinQuiz { get; set; }
        public HairQuiz HairQuiz { get; set; }

    }
}
