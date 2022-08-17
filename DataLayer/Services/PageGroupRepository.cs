using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataLayer
{
    public class PageGroupRepository : IPageGroupRepository
    {
        private MyCmsContext _context;
        public PageGroupRepository(MyCmsContext context)
        {
            this._context = context;
        }

        #region Delete Group
        public bool DeleteGroup(PageGroup pagegroup)
        {
            try
            {
                _context.Entry(pagegroup).State = EntityState.Deleted;
                return true;
            }
            catch (Exception) { return false; }
        }

        public bool DeleteGroup(int GroupID)
        {
            try
            {
                DeleteGroup(GetPageGroupByID(GroupID));
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

        #region Get All Groups
        public IEnumerable<PageGroup> GetAllGroups()
        {
            return _context.PageGroups;
        }
        #endregion

        #region Get Groups For View
        public IEnumerable<ShowGroupViewModel> GetGroupsForView()
        {
            return _context.PageGroups.Select(g => new ShowGroupViewModel()
            {
                GroupID = g.GroupID,
                GroupTitle = g.GroupTitle,
                PageCount = g.Pages.Count()
            });
        }
        #endregion

        #region Get Page Group By ID
        public PageGroup GetPageGroupByID(int GroupID)
        {
            return _context.PageGroups.Find(GroupID);
        }
        #endregion

        #region Insert Group
        public bool InsertGroup(PageGroup pagegroup)
        {
            try
            {
                _context.PageGroups.Add(pagegroup);
                return true;
            }
            catch (Exception) { return false; }
        }
        #endregion

        #region Save
        public void Save()
        {
            _context.SaveChanges();
        }
        #endregion

        #region Update Group
        public bool UpdateGroup(PageGroup pagegroup)
        {
            try
            {
                _context.Entry(pagegroup).State = EntityState.Modified;
                return true;
            }
            catch (Exception) { return false; }
        }
        #endregion
    }
}
