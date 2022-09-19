using BoardRenual.Biz.User;
using BoardRenual.Models.RequestModel.User;
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
        public JsonResult SignUp(UserSignUpEntity userSignUpEntity)
        {
            SignUpBiz signUpBiz = new SignUpBiz();
            return Json(signUpBiz.UserSignUp(userSignUpEntity));
        }
        [HttpPost]
        public JsonResult EmailCheck(UserEmailCheckEntity userEmailCheck)
        {
            EmailCheckBiz emailCheckBiz = new EmailCheckBiz();
            return Json(emailCheckBiz.UserSignUp(userEmailCheck));
        }
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
    }
}