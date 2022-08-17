using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataLayer
{
    public class PageRepository : IPageRepository
    {
        private MyCmsContext _context;
        public PageRepository(MyCmsContext context)
        {
            this._context = context;
        }

        #region Delete Page
        public bool DeletePage(Page page)
        {
            try
            {
                _context.Entry(page).State = EntityState.Deleted;
                return true;
            }
            catch (Exception) { return false; }
        }

        public bool DeletePage(int PageID)
        {
            try
            {
                DeletePage(GetPageByID(PageID));
                return true;
            }
            catch (Exception) { return false; }
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            _context.Dispose();
        }
        #endregion

        #region Get All Pages
        public IEnumerable<Page> GetAllPages()
        {
            return _context.Pages;
        }
        #endregion

        #region Get Page By ID
        public Page GetPageByID(int PageID)
        {
            return _context.Pages.Find(PageID);
        }
        #endregion

        #region Insert Page
        public bool InsertPage(Page page)
        {
            try
            {
                _context.Pages.Add(page);
                return true;
            }
            catch (Exception) { return false; }
        }
        #endregion

        #region Latest News
        public IEnumerable<Page> LatestNews(int take = 4)
        {
            return _context.Pages.OrderByDescending(p => p.CreateDate).Take(take);
        }
        #endregion

        #region Pages In Slider
        public IEnumerable<Page> PagesInSlider()
        {
            return _context.Pages.Where(p => p.ShowInSlider);
        }
        #endregion

        #region Save
        public void Save()
        {
            _context.SaveChanges();
        }
        #endregion

        #region Search Page
        public IEnumerable<Page> SearchPage(string search)
        {
            return _context.Pages.Where(p => p.Title.Contains(search) || p.ShortDescription.Contains(search) || p.Article.Contains(search) || p.Tags.Contains(search)).Distinct();
        }
        #endregion

        #region Show Page By GroupID
        public IEnumerable<Page> ShowPageByGroupID(int groupid)
        {
            return _context.Pages.Where(p => p.GroupID == groupid);
        }
        #endregion

        #region Top News
        public IEnumerable<Page> TopNews(int take = 4)
        {
            return _context.Pages.OrderByDescending(p => p.Visit).Take(take);
        }
        #endregion

        #region Update Page
        public bool UpdatePage(Page page)
        {
            try
            {
                _context.Entry(page).State = EntityState.Modified;
                return true;
            }
            catch (Exception) { return false; }
        }
        #endregion
    }
}
