using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace soFine.Models
{
    public class Article
    {
        public int Id { get; set; }

        [DisplayName("Title")]
        [Required(ErrorMessage = "Article's title is required")]
        public string Title { get; set; }

        [DisplayName("Article text")]
        [Required(ErrorMessage = "Article's text is required")]
        public string ArticleText { get; set; }

        [DisplayName("Author")]
        [Required(ErrorMessage = "Article's author is required")]
        public string Author { get; set; } 
        public int IdSpecialist { get; set; }
    }
}