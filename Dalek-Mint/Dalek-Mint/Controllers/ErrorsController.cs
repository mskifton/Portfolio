using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dalek_Mint.Controllers
{
    public class ErrorsController : Controller
    {
        public ActionResult Index()
        {
            return View("DefaultError");
        }

        public ActionResult NotFound()
        {
            return View("Oops");
        }
    }
}