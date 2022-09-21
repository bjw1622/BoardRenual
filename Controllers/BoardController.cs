using BoardRenual.Biz.Board;
using BoardRenual.Models.Request.Board;
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
            BoardGetBoardListBiz boardGetBoardListBiz = new BoardGetBoardListBiz();
            return View(boardGetBoardListBiz.GetBoardList());
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
            return Json(
                new
                {
                    result = boardWriteBiz.WriteBoard(boardWriteModel)
                }
                );
        }
        [HttpGet]
        public ActionResult Detail(int No)
        {
            BoardGetBoardDetailBiz boardGetBoardDetailBiz = new BoardGetBoardDetailBiz();
            BoardGetBoardEmailBiz boardGetBoardEmailBiz = new BoardGetBoardEmailBiz();
            if (boardGetBoardEmailBiz.GetBoardEmail(No).Email == Request.Cookies["Email"].Value)
            {
                ViewBag.EmailCheck = true;
            }
            else
            {
                ViewBag.EmailCheck = false;
            }
            return View(boardGetBoardDetailBiz.GetBoardDetail(No));
        }
        [HttpPost]
        public JsonResult Delete(int No)
        {
            BoardDeleteBoardBiz boardDeleteBoardBiz = new BoardDeleteBoardBiz();
            return Json(new
            {
                flag = boardDeleteBoardBiz.DeleteBoard(No)
            });
        }
        [HttpPost]
        public JsonResult Update(BoardUpdateRequestModel boardUpdateRequestModel)
        {
            BoardUpdateBiz boardUpdateBiz = new BoardUpdateBiz();
            return Json(new
            {
                flag = boardUpdateBiz.UpdateBoard(boardUpdateRequestModel)
            });
        }
    }
}