using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace soFine.Models
{
    public class SkinQuiz
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public List<SkinAnswer> Answer { get; set; }
       }
}
