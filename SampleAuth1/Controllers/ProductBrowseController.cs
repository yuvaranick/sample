using SampleAuth1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SampleAuth1.Controllers
{
    public class ProductBrowseController : Controller
    {
        private MyDbContext db = new MyDbContext();
        // GET: ProductBrowse/Index
        public ActionResult Index()
        {
            var list = (from product in db.Products
                        where product.Category == 1000
                        select product).ToList();
            if (list == null)
            {
                return HttpNotFound();
            }
            return View(list);
            
        }

        // GET: ProductBrowse/Favorites
        public ActionResult Favorites(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var list = (from product in db.Products
                        where product.Category == id
                        select product).ToList();
            if (list == null)
            {
                return HttpNotFound();
            }
            return View("Index", list);
            
        }
    }
}