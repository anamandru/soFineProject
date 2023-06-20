using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace soFine.Models
{
    public class Question
    {
        public int Id {get ;set;}

        [DisplayName("Question:")]
        [Required(ErrorMessage = "Can't send a question without text!")]
        public string QuestionText { get; set;}

        [DisplayName("Answer:")]
        public string AnswerText { get; set;}
        public int IdUser { get; set;}
        public string AnsweredBy {get; set;}

    }
}