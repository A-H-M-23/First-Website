using System;
using System.Collections.Generic;

namespace DataLayer
{
    public interface IPageGroupRepository : IDisposable
    {
        IEnumerable<PageGroup> GetAllGroups();
        PageGroup GetPageGroupByID(int GroupID);
        bool InsertGroup(PageGroup pagegroup);
        bool UpdateGroup(PageGroup pagegroup);
        bool DeleteGroup(PageGroup pagegroup);
        bool DeleteGroup(int GroupID);
        void Save();

        IEnumerable<ShowGroupViewModel> GetGroupsForView();
    }
}
