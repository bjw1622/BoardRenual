using BoardRenual.Biz.User;
using BoardRenual.Models.OrginalModel.User;
using BoardRenual.Models.Request.User;
using System;
using System.Web.Mvc;

namespace BoardRenual.Controllers
{
    public class UserController : Controller
    {
        /// <summary>
        /// User 회원 가입 페이지
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        /// <summary>
        /// User 회원 가입 Http post 
        /// </summary>
        /// <param name="userSignUp"></param>
        /// <returns>bool</returns>
        [HttpPost]
        public JsonResult SignUp(UserSignUpRequestModel userSignUp)
        {
            bool result = false;
            if(userSignUp != null && !(string.IsNullOrEmpty(userSignUp.Email)) && 
                !(string.IsNullOrEmpty(userSignUp.Pw)) && !(string.IsNullOrEmpty(userSignUp.Name)) && userSignUp.Birth != null)
            {
                result = new UserSignUpBiz().UserSignUp(userSignUp);
            }
            return Json(result);

        }
        /// <summary>
        /// User 회원 가입 이메일 중복 체크
        /// </summary>
        /// <param name="userEmailCheck"></param>
        /// <returns>int result</returns>
        [HttpPost]
        public JsonResult EmailCheck(UserEmailCheckRequestModel userEmailCheck)
        {
            int result = 0;
            if(userEmailCheck != null && !(string.IsNullOrEmpty(userEmailCheck.Email)))
            {
                result = new UserEmailCheckBiz().EmailCheck(userEmailCheck);
            }
            return Json(result);
        }
        /// <summary>
        /// User 로그인
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]  
        public ActionResult LogIn()
        {
            if (Request.Cookies["Email"] != null)
            {
                return RedirectToAction("Index", "Board");
            }
            return View();
        }
        /// <summary>
        /// User 로그인 Http Post
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult LogIn(UserLogInRequestModel userLogin)
        {
            if(userLogin != null && !(string.IsNullOrEmpty(userLogin.Email)) && !(string.IsNullOrEmpty(userLogin.Pw)))
            {
                UserOriginalModel result = new UserLogInBiz().SignIn(userLogin);
                if (result.Email != null)
                {
                    Response.Cookies["UserName"].Value = Server.UrlEncode(result.Name);
                    Response.Cookies["Email"].Value = result.Email;
                    //Response.Cookies["UserName"].Expires = DateTime.Now.AddMinutes(5);
                    //Response.Cookies["Email"].Expires = DateTime.Now.AddMinutes(5);
                    return RedirectToAction("Index", "Board");
                }
            }
            return Content("<script language='javascript' type='text/javascript'> " +
                "alert('로그인 정보가 일치하지 않습니다.');" +
                "location.href='/User/Login'" +
                "</script>");
        }
        /// <summary>
        /// User 로그아웃
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        public ActionResult Logout()
        {
            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Email"].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("Login", "User");
        }
    }
}