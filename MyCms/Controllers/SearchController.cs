using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCms.Controllers
{
    public class SearchController : Controller
    {
        MyCmsContext context = new MyCmsContext();
        IPageRepository pageRepository;
        public SearchController()
        {
            pageRepository = new PageRepository(context);
        }

        // GET: Search
        public ActionResult Index(string q)
        {
            ViewBag.Search = q;
            return View(pageRepository.SearchPage(q));
        }
    }
}