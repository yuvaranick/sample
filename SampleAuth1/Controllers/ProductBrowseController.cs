using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleAuth1.Controllers
{
    public class ProductBrowseController : Controller
    {
        // GET: ProductBrowse/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductBrowse/Favorites
        public ActionResult Favorites()
        {
            return View();
        }
    }
}