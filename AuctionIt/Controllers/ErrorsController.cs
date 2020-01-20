using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuctionIt.Controllers
{
    public class ErrorsController : Controller
    {
        // GET: Errors
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Error500(string message)
        {
            ViewBag.Message = message;
            return View();
        }
        public ActionResult Error404(string message)
        {
            return View();
        }
    }
}