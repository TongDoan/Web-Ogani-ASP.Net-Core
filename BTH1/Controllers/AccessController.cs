using BTH1.Models;
using Microsoft.AspNetCore.Mvc;

namespace BTH1.Controllers
{
    public class AccessController : Controller
    {
        QlbanVaLiContext db = new QlbanVaLiContext();
        [HttpGet]
        public IActionResult Login()
        {
            if(HttpContext.Session.GetString("UserName" ) == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
        [HttpPost]
        public IActionResult Login(TUser user)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                var obj = db.TUsers.Where(x => x.Username == user.Username && x.Password == user.Password && x.LoaiUser == 0).FirstOrDefault();
                if(obj != null)
                {
                    HttpContext.Session.SetString("UserName", obj.Username.ToString());
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("HomeAdmin", "Admin");
                }
            }
            return View();
        }
    }
}
