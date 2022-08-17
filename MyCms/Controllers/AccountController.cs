using DataLayer;
using System.Web.Mvc;
using System.Web.Security;

namespace MyCms.Controllers
{
    public class AccountController : Controller
    {
        MyCmsContext context = new MyCmsContext();
        ILoginRepository loginRepository;
        public AccountController()
        {
            loginRepository = new LoginRepository(context);
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login ,string ReturnUrl="/")
        {
            if (ModelState.IsValid)
            {
                if (loginRepository.IsUserExist(login.UserName, login.Password))
                {
                    FormsAuthentication.SetAuthCookie(login.UserName, login.RememberMe);
                    return Redirect(ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("UserName", "کاربری با این مشخصات یافت نشد.");
                }
            }
            return View(login);
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}