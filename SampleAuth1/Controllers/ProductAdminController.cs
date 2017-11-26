using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleAuth1.Controllers
{
    public class ProductAdminController : Controller
    {
        // GET: ProductAdmin
        public ActionResult Index()
        {
            ViewBag.Message = "This is Product Admin Page";
            return View();
        }
        public ActionResult ManageProducts()
        {

            
            return View();
        }
        public ActionResult ManageCategory()
        {


            return View();
        }

    }
}
