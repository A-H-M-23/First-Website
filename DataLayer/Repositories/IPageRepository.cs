using System;
using System.Collections.Generic;

namespace DataLayer
{
    public interface IPageRepository : IDisposable
    {
        IEnumerable<Page> GetAllPages();
        Page GetPageByID(int PageID);
        bool InsertPage(Page page);
        bool UpdatePage(Page page);
        bool DeletePage(Page page);
        bool DeletePage(int PageID);
        void Save();

        IEnumerable<Page> TopNews(int take = 4);
        IEnumerable<Page> PagesInSlider();
        IEnumerable<Page> LatestNews(int take = 4);
        IEnumerable<Page> ShowPageByGroupID(int groupid);
        IEnumerable<Page> SearchPage(string search);
    }
}
