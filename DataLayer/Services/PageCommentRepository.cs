using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class PageCommentRepository : IPageCommentRepository
    {
        private MyCmsContext _context;
        public PageCommentRepository(MyCmsContext context)
        {
            this._context = context;
        }

        #region Add Comment
        public bool AddComment(PageComment comment)
        {
            try
            {
                _context.PageComments.Add(comment);
                _context.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }
        #endregion

        #region Get Comment By News ID
        public IEnumerable<PageComment> GetCommentByNewsID(int PageID)
        {
            return _context.PageComments.Where(pc => pc.PageID == PageID);
        }
        #endregion
    }
}
