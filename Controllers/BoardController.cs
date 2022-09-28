using BoardRenual.Biz.Board;
using BoardRenual.Biz.Recommand;
using BoardRenual.Models.Request.Board;
using BoardRenual.Models.Request.Page;
using BoardRenual.Models.Request.Recommand;
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
        // 글작성
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
        // 상세
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
        // 삭제
        [HttpPost]
        public JsonResult Delete(int No)
        {
            BoardDeleteBoardBiz boardDeleteBoardBiz = new BoardDeleteBoardBiz();
            return Json(new
            {
                flag = boardDeleteBoardBiz.DeleteBoard(No)
            });
        }
        // 수정
        [HttpPost]
        public JsonResult Update(BoardUpdateRequestModel boardUpdateRequestModel)
        {
            BoardUpdateBiz boardUpdateBiz = new BoardUpdateBiz();
            return Json(new
            {
                flag = boardUpdateBiz.UpdateBoard(boardUpdateRequestModel)
            });
        }
        [HttpGet]
        // 페이징
        public JsonResult IndexPaging(PageRequestModel pageRequestModel)
        {
            BoardPagingBiz boardPagingBiz = new BoardPagingBiz();
            return Json(new
            { Paging = boardPagingBiz.IndexPagingBoard(pageRequestModel) }, JsonRequestBehavior.AllowGet
        );
        }
        [HttpGet]
        // 검색 + 페이징
        public JsonResult PageAndFind(FindAndPageRequestModel findAndPageRequestModel)
        {
            BoardFindAndPageRequestBiz boardFindAndPageRequestBiz = new BoardFindAndPageRequestBiz();
            BoardFindAndPageCountRequestBiz boardFindAndPageCountRequestBiz = new BoardFindAndPageCountRequestBiz();
            return Json(new
            {
                Result = boardFindAndPageCountRequestBiz.PageAndFindBoardCount(findAndPageRequestModel),
                Paging = boardFindAndPageRequestBiz.PageAndFindBoard(findAndPageRequestModel)
            },
                JsonRequestBehavior.AllowGet
        );
        }
        [HttpPost]
        // 검색 + 페이징
        public JsonResult Recommand(RecommandInfoRequestModel recommandInfoRequestModel)
        {
            // 해당 이메일 추천 기록있는지
            RecommandInfoBiz recommandInfo = new RecommandInfoBiz();
            int recommandInfoNum = recommandInfo.GetRecommandInfo(recommandInfoRequestModel);
            // 추천이 이미 됨 => 취소
            if(recommandInfoNum == 1)
            {
                Console.WriteLine(recommandInfo);
            }
            // 추천 내역 없음 => 추천
            else if(recommandInfoNum == 0)
            {
                Console.WriteLine(recommandInfo);
            }
            return Json(new { test = "a" });
        }

    }
}