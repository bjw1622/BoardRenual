using BoardRenual.Models.RequestModel.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoardRenual.Controllers
{
    public class BoardController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Write()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Write(BoardWriteModel boardWriteModel)
        {
            return View();
        }
    }
}