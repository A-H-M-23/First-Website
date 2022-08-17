using DataLayer;
using System;
using System.Web.Mvc;

namespace MyCms.Controllers
{
    public class NewsController : Controller
    {
        MyCmsContext context = new MyCmsContext();
        IPageGroupRepository pageGroupRepository;
        IPageRepository pageRepository;
        IPageCommentRepository pageCommentRepository;
        public NewsController()
        {
            pageGroupRepository = new PageGroupRepository(context);
            pageRepository = new PageRepository(context);
            pageCommentRepository = new PageCommentRepository(context);
        }
        // GET: News
        public ActionResult ShowGroups()
        {
            return PartialView(pageGroupRepository.GetGroupsForView());
        }

        public ActionResult ShowGroupsInMenu()
        {
            return PartialView(pageGroupRepository.GetAllGroups());
        }

        public ActionResult TopNews()
        {
            return PartialView(pageRepository.TopNews());
        }

        [Route("Archive")]
        public ActionResult ArchiveNews()
        {
            return View(pageRepository.GetAllPages());
        }

        [Route("Group/{ID}/{Title}")]
        public ActionResult ShowNewsByGroupID(int ID , string Title)
        {
            ViewBag.Name = Title;
            return View(pageRepository.ShowPageByGroupID(ID));
        }

        [Route("News/{ID}")]
        public ActionResult ShowNews(int ID)
        {
            var news = pageRepository.GetPageByID(ID);
            if(Equals(news , null))
                return HttpNotFound();

            news.Visit += 1;
            pageRepository.UpdatePage(news);
            pageRepository.Save();

            return View(news);
        }

        public ActionResult AddComment(int ID , string Name , string Email , string CommentText)
        {
            PageComment comment = new PageComment()
            {
                CreateDate = DateTime.Now,
                PageID = ID,
                Name = Name,
                Email = Email,
                Comment = CommentText
            };

            pageCommentRepository.AddComment(comment);

            return PartialView("ShowComments" , pageCommentRepository.GetCommentByNewsID(ID));
        }

        public ActionResult ShowComments(int ID)
        {
            return PartialView(pageCommentRepository.GetCommentByNewsID(ID));
        }
    }
}