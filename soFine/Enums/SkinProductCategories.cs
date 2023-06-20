using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace soFine.Enums
{
    public class SkinProductCategories
    {
        public List<string> skinproductcategories = new List<string>();

        public SkinProductCategories()
        {
            skinproductcategories.Add("Cleanser");
            skinproductcategories.Add("Exfoliator");
            skinproductcategories.Add("Treatment");
            skinproductcategories.Add("Serum");
            skinproductcategories.Add("Face Oil");
            skinproductcategories.Add("Sunscreen");
            skinproductcategories.Add("Moisturizer");
            skinproductcategories.Add("Toner");
            skinproductcategories.Add("Face Mask");
            skinproductcategories.Add("Eye Cream");
        }
    }
}