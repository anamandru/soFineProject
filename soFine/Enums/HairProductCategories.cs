using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace soFine.Enums
{
    public class HairProductCategories
    {
        public List<string> Hairproductcategories = new List<string>();

        public HairProductCategories()
        {
            Hairproductcategories.Add("Shampoo");
            Hairproductcategories.Add("Conditioner");
            Hairproductcategories.Add("Dry Shampoo");
            Hairproductcategories.Add("Heat protectant spray");
            Hairproductcategories.Add("Oil");
            Hairproductcategories.Add("Hairspray");
            Hairproductcategories.Add("Mask");
            Hairproductcategories.Add("Serum");
        }
    }
}