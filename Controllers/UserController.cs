using BoardRenual.Biz;
using BoardRenual.Models;
using System.Web.Mvc;

namespace BoardRenual.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SignUp(UserEntity userEntity)
        {
            User user = new User();
            return Json(user.SignUp(userEntity));
        }
        [HttpPost]
        public JsonResult EmailCheck(string email)
        {
            User user = new User();
            int result = user.EmailCheck(email);
            return Json(result);
        }

        public ActionResult LogIn()
        {
            return View();
        }
    }
}