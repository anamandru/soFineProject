using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace soFine.Models
{
    public class HairProduct
    {
        public int Id { get; set; }

        [DisplayName("Product name")]
        [Required(ErrorMessage = "Product's name is required")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "A description is required")]
        public string Description { get; set; }

        [DisplayName("Hair type")]
        public string HairType { get; set; }

        [DisplayName("Category")]
        [Required]
        public string Category { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }
        public byte[] ImageData { get; set; }
        //public List<UserAccount> Users { get; set; }
    }
}
