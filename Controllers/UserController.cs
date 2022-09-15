using BoardRenual.Entitys;
using BoardRenual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult SignUp(UserEntity userEntity)
        {
            User user = new User();
            user.SignUp(userEntity);
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }
    }
}