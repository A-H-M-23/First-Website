using System.Linq;

namespace DataLayer
{
    public class LoginRepository : ILoginRepository
    {
        MyCmsContext _context;
        public LoginRepository(MyCmsContext context)
        {
            _context = context;
        }

        public bool IsUserExist(string username, string password)
        {
            return _context.AdminLogins.Any(l=>l.UserName==username && l.Password==password);
        }
    }
}
