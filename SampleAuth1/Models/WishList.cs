using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleAuth1.Models
{
    public class WishList
    {
        public int Id { set; get; }
        public string ASIN { set; get; }
        public virtual ApplicationUser User { get; set; }
        public virtual Product Product { get; set; }
        public WishList()
        {
            User = new ApplicationUser();
            Product = new Product();
        }
    }
}