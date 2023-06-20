using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace soFine.Models
{
    public class UsersSkinProduct
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}