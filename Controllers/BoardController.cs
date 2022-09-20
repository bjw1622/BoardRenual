using BoardRenual.Biz.Board;
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
            BoardWriteBiz boardWriteBiz = new BoardWriteBiz();
            return View(boardWriteBiz.GetBoardList());
        }
        [HttpGet]
        public ActionResult Write()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Write(BoardWriteRequestModel boardWriteModel)
        {
            BoardWriteBiz boardWriteBiz = new BoardWriteBiz();
            return Json(boardWriteBiz.InsertBoard(boardWriteModel));
        }
        [HttpGet]
        public ActionResult Detail(int No)
        {
            BoardWriteBiz boardWriteBiz = new BoardWriteBiz();
            return View(boardWriteBiz.GetBoardDetail(No));
        }
    }
}