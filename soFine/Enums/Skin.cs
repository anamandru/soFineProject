using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace soFine.Enums
{
    public class Skin
    {
        public List<string> skinTypes = new List<string>();

        public Skin() {
            skinTypes.Add("normal");
            skinTypes.Add("dry");
            skinTypes.Add("oily");
            skinTypes.Add("combination");
            skinTypes.Add("sensitive");
        }
    }
}