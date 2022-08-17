using System.Collections.Generic;

namespace DataLayer
{
    public interface IPageCommentRepository
    {
        IEnumerable<PageComment> GetCommentByNewsID(int PageID);
        bool AddComment(PageComment comment);
    }
}
