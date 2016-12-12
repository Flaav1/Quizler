using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using SAP.Models;

namespace SAP.Controllers
{
    public class PartialController : Controller
    {
        // GET: Partial
        public ActionResult Play()
        {
            return View();
        }

        public ActionResult Scoreboard()
        {
            return View();
        }

        public ActionResult AddQuestion()
        {
            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Welcome()
        {
            return View();
        }


    }
}