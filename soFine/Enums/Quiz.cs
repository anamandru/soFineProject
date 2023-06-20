using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace soFine.Enums
{
    public class Quiz
    {
        public int number;
        string answer;

        public Quiz(int number, string answer)
        {
            this.number = number;
            this.answer = answer;
        }
    }
}