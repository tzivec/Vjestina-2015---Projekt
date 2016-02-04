using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SurveyBuilder.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Survey Builder";

            return View();
        }

        public ActionResult Home()
        {
            return PartialView();
        }

        public ActionResult Surveys()
        {
            return PartialView();
        }

        public ActionResult NewSurvey()
        {
            return PartialView();
        }

        public ActionResult TakeSurvey()
        {
            return PartialView();
        }

        public ActionResult SurveyComplete()
        {
            return PartialView();
        }


        public ActionResult ActiveSurveys()
        {
            return PartialView();
        }

        public ActionResult FilledSurveys()
        {
            return PartialView();
        }

        public ActionResult ClosedSurveys()
        {
            return PartialView();
        }

        public ActionResult Statistics()
        {
            return PartialView();
        }
        
    }
}
