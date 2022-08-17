using DataLayer;
using System;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Page = DataLayer.Page;

namespace MyCms.Areas.Admin.Controllers
{
    [Authorize]
    public class PagesController : Controller
    {
        MyCmsContext DB = new MyCmsContext();
        IPageRepository pageRepository;
        IPageGroupRepository pageGroupRepository;
        public PagesController()
        {
            pageRepository = new PageRepository(DB);
            pageGroupRepository = new PageGroupRepository(DB);
        }

        // GET: Admin/Pages
        public ActionResult Index()
        {
            return View(pageRepository.GetAllPages());
        }

        // GET: Admin/Pages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = pageRepository.GetPageByID(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // GET: Admin/Pages/Create
        public ActionResult Create()
        {
            ViewBag.GroupID = new SelectList(pageGroupRepository.GetAllGroups(), "GroupID", "GroupTitle");
            return View();
        }

        // POST: Admin/Pages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PageID,GroupID,Title,ShortDescription,Article,Visit,ImagePath,ShowInSlider,CreateDate,Tags")] Page page , HttpPostedFileBase imgUpload)
        {
            if (ModelState.IsValid)
            {
                page.Visit = 0;
                page.CreateDate = DateTime.Now;

                if(imgUpload != null)
                {
                    page.ImagePath = Guid.NewGuid() + Path.GetExtension(imgUpload.FileName);
                    imgUpload.SaveAs(Server.MapPath("/PageImages/" + page.ImagePath));
                }

                pageRepository.InsertPage(page);
                pageRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.GroupID = new SelectList(pageGroupRepository.GetAllGroups(), "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }

        // GET: Admin/Pages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = pageRepository.GetPageByID(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupID = new SelectList(pageGroupRepository.GetAllGroups(), "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }

        // POST: Admin/Pages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PageID,GroupID,Title,ShortDescription,Article,Visit,ImagePath,ShowInSlider,CreateDate,Tags")] Page page , HttpPostedFileBase imgUpload)
        {
            if (ModelState.IsValid)
            {
                if (imgUpload != null)
                {
                    if(page.ImagePath != null)
                        System.IO.File.Delete(Server.MapPath("/PageImages/" + page.ImagePath));

                    page.ImagePath = Guid.NewGuid() + Path.GetExtension(imgUpload.FileName);
                    imgUpload.SaveAs(Server.MapPath("/PageImages/" + page.ImagePath));
                }

                pageRepository.UpdatePage(page);
                pageRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(pageGroupRepository.GetAllGroups(), "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }

        // GET: Admin/Pages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = pageRepository.GetPageByID(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // POST: Admin/Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var page = pageRepository.GetPageByID(id);
            if (page.ImagePath != null)
                System.IO.File.Delete(Server.MapPath("/PageImages/" + page.ImagePath));
            pageRepository.DeletePage(page);
            pageRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                pageGroupRepository.Dispose();
                pageRepository.Dispose();
                DB.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
