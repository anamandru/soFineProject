using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace soFine.Models
{
    public class UsersHairProduct
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}