using BoardRenual.Biz.User;
using BoardRenual.Models.OrginalModel.User;
using BoardRenual.Models.RequestModel.User;
using System;
using System.Web;
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
        public JsonResult SignUp(UserSignUpModel userSignUp)
        {
            UserSignUpBiz signUpBiz = new UserSignUpBiz();
            return Json(signUpBiz.UserSignUp(userSignUp));
        }
        [HttpPost]
        public JsonResult EmailCheck(UserEmailCheckModel userEmailCheck)
        {
            UserEmailCheckBiz emailCheckBiz = new UserEmailCheckBiz();
            return Json(emailCheckBiz.UserSignUp(userEmailCheck));
        }
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(UserLogInModel userLogin)
        {
            UserLogInBiz userLogInBiz = new UserLogInBiz();
            UserModel result = userLogInBiz.UserSignUp(userLogin);
            if (result.Email != null)
            {
                Response.Cookies["UserName"].Value = Server.UrlEncode(result.Name);
                Response.Cookies["Email"].Value = result.Email;
                return RedirectToAction("Index", "Board");

            }
            return Content("<script language='javascript' type='text/javascript'> " +
                "alert('로그인 정보가 일치하지 않습니다.');" +
                "location.href='/User/Login'" +
                "</script>");
        }
        public ActionResult Logout()
        {
            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Email"].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("Login", "User");
        }
    }
}