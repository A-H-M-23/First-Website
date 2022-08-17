using System.Data.Entity;

namespace DataLayer
{
    public class MyCmsContext : DbContext
    {
        public DbSet<AdminLogin> AdminLogins { get; set; }
        public DbSet<PageGroup> PageGroups { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PageComment> PageComments { get; set; }
    }
}
