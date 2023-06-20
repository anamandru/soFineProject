using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace soFine.Models
{
    public class HairQuiz
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public List<HairAnswer> Answer { get; set; }
    }

}
