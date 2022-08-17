using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCms.Controllers
{
    public class HomeController : Controller
    {
        MyCmsContext context = new MyCmsContext();
        IPageRepository pageRepository;
        public HomeController()
        {
            pageRepository = new PageRepository(context);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Slider()
        {
            return PartialView(pageRepository.PagesInSlider());
        }

        public ActionResult LatestNews()
        {
            return PartialView(pageRepository.LatestNews());
        }
    }
}