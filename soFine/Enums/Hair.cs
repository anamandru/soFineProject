using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace soFine.Enums
{    
    public class Hair
    {
        public List<string> hairTypes = new List<string>();

        public Hair()
        {
            hairTypes.Add("Oily");
            hairTypes.Add("Normal");
            hairTypes.Add("Dry");           
            hairTypes.Add("Curly");
        }
        
    }
}