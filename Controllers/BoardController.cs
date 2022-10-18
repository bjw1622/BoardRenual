using BoardRenual.Biz.Board;
using BoardRenual.Biz.Recommand;
using BoardRenual.Biz.Reply;
using BoardRenual.Models.Request.Board;
using BoardRenual.Models.Request.Page;
using BoardRenual.Models.Request.Recommand;
using BoardRenual.Models.Request.Reply;
using BoardRenual.Models.RequestModel.Board;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace BoardRenual.Controllers
{
    public class BoardController : Controller
    {
        private bool CookieCheck()
        {
            if (Request.Cookies["Email"] != null)
            {
                return true;
            }
            return false;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View(new BoardGetBoardListBiz().GetBoardList());
        }
        [HttpGet]
        public ActionResult Write()
        {
            if (Request.Cookies["Email"] != null)
            {
                return View();
            }
            return Content("<script language='javascript' type='text/javascript'> " +
                "alert('글쓰기를 위해서 로그인 해주세요.');" +
                "location.href='/Board/Index'" +
                "</script>");
        }
        // 글작성
        public JsonResult Write(BoardWriteRequestModel boardWriteRequestModel)
        {
            int boardNo = -1;
            if (boardWriteRequestModel == null)
            {
                return Json(boardNo);
            }
            if (!(string.IsNullOrEmpty(boardWriteRequestModel.Title)) && !(string.IsNullOrEmpty(boardWriteRequestModel.Content))
                && !(string.IsNullOrEmpty(boardWriteRequestModel.Email)))
            {
                boardNo = new BoardWriteBiz().WriteBoard(boardWriteRequestModel);
            }
            if (boardNo != -1)
            {
                UploadFiles(boardWriteRequestModel.FormData);
                new BoardWriteFileBiz().WriteFileBoard(boardNo, boardWriteRequestModel.FileName);
            }
            return Json(boardNo);

        }
        // 첨부파일 로컬 저장
        [HttpPost]
        public void UploadFiles(List<Object> Formdata)
        {
            if (Formdata.Count > 0)
            {
                var files = Formdata;
                foreach (string str in files)
                {
                    HttpPostedFileBase file = Request.Files[str] as HttpPostedFileBase;
                    if (file != null)
                    {
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/Uploads/") + InputFileName);
                        file.SaveAs(ServerSavePath);
                    }
                }
            }
        }
        // 상세
        [HttpGet]
        public ActionResult Detail(int no)
        {
            if (no > 0)
            {
                if (Request.Cookies["Email"] == null || new BoardGetBoardEmailBiz().GetBoardEmail(no).Email != Request.Cookies["Email"].Value)
                {
                    ViewBag.EmailCheck = false;
                }
                else
                {
                    ViewBag.EmailCheck = true;
                }
                ViewBag.RecommandCount = new RecommandGetCountBiz().GetRecommandCount(no);
                ViewBag.FileInfoList = new BoardGetFileInfoBiz().BoardGetFileInfo(no);
                ViewBag.ReplyList = new ReplyGetReplyListBiz().GetReplyList(no);
                ViewBag.BoardDetail = new BoardGetBoardDetailBiz().GetBoardDetail(no);
                return View();
            }
            return RedirectToAction("Index", "Board");
        }
        // 삭제
        [HttpPost]
        public JsonResult Delete(int no)
        {
            if (no > 0)
            {
                return Json(new BoardDeleteBoardBiz().DeleteBoard(no));
            }
            return Json(new BoardDeleteBoardBiz().DeleteBoard(no));
        }
        // 수정
        [HttpPost]
        public JsonResult Update(BoardUpdateRequestModel boardUpdateRequestModel)
        {
            if (boardUpdateRequestModel != null && boardUpdateRequestModel.No > 0 && !(string.IsNullOrEmpty(boardUpdateRequestModel.Title))
                && !(string.IsNullOrEmpty(boardUpdateRequestModel.Content)))
            {
                return Json(new BoardUpdateBiz().UpdateBoard(boardUpdateRequestModel));
            }
            return Json(new BoardUpdateBiz().UpdateBoard(boardUpdateRequestModel));
        }
        // 페이징
        [HttpGet]
        public JsonResult IndexPaging(PageRequestModel pageRequestModel)
        {
            if (pageRequestModel != null && pageRequestModel.PageNumber > 0 && pageRequestModel.PageCount > 0)
            {
                return Json(new
                { Paging = new BoardPagingBiz().IndexPagingBoard(pageRequestModel) }, JsonRequestBehavior.AllowGet
        );
            }
            return Json(new
            {
                Paging = -1
            }
                    );

        }
        // 검색 + 페이징
        [HttpGet]
        public JsonResult PageAndFind(FindAndPageRequestModel findAndPageRequestModel)
        {
            if (findAndPageRequestModel != null && findAndPageRequestModel.PageNumber > 0 && findAndPageRequestModel.PageCount > 0 &&
                !(string.IsNullOrEmpty(findAndPageRequestModel.Variable)) && !(string.IsNullOrEmpty(findAndPageRequestModel.Input)))
            {
                return Json(new
                {
                    Result = new BoardFindAndPageCountRequestBiz().PageAndFindBoardCount(findAndPageRequestModel),
                    Paging = new BoardFindAndPageRequestBiz().PageAndFindBoard(findAndPageRequestModel)
                }, JsonRequestBehavior.AllowGet
        );
            }
            return Json(
                new
                {
                    Result = -1,
                    Paging = -1,
                }, JsonRequestBehavior.AllowGet
            );
        }
        // 추천
        [HttpPost]
        public JsonResult Recommand(RecommandInfoRequestModel recommandInfoRequestModel)
        {
            int flag = -1;
            int recommandCount = -1;
            if (recommandInfoRequestModel != null && recommandInfoRequestModel.BoardNo > 0 && !(string.IsNullOrEmpty(recommandInfoRequestModel.Email)))
            {
                int recommandInfoNum = new RecommandInfoBiz().GetRecommandInfo(recommandInfoRequestModel);
                if (recommandInfoNum == 1)
                {
                    new RecommandDeleteBiz().RecommandDelete(recommandInfoRequestModel);
                    flag = 1;
                }
                else if (recommandInfoNum == 0)
                {
                    new RecommandInsertBiz().RecommandInsert(recommandInfoRequestModel);
                    flag = 0;
                }
                recommandCount = new RecommandGetCountBiz().GetRecommandCount(recommandInfoRequestModel.BoardNo);
                return Json(new
                {
                    Flag = flag
                ,
                    RecommandCount = recommandCount
                });
            }
            return Json(new
            {
                Flag = flag
                ,
                RecommandCount = recommandCount
            });
        }
        // 댓글,답글 작성
        [HttpPost]
        public JsonResult WriteReply(ReplyWriteRequestModel replyWriteRequestModel)
        {
            bool writeResult = false;
            if (replyWriteRequestModel != null && replyWriteRequestModel.BoardNo > 0 && replyWriteRequestModel.ParentReplyNo >= 0 && !(string.IsNullOrEmpty(replyWriteRequestModel.Content)) && !(string.IsNullOrEmpty(replyWriteRequestModel.Email)))
            {
                return Json(new
                {
                    WriteResult = new ReplyWriteBiz().ReplyWrite(replyWriteRequestModel),
                    ReplyList = new ReplyGetReplyListBiz().GetReplyList(replyWriteRequestModel.BoardNo),
                });
            }
            return Json(new
            {
                WriteResult = writeResult,
            });
        }
        // 답글 불러오기
        [HttpPost]
        public JsonResult GetReReplyList(int parentReplyNo)
        {
            if (parentReplyNo > 0)
            {
                return Json(new ReplyGetReReplyListBiz().ReplyGetReReplyList(parentReplyNo));
            }
            return Json(new ReplyGetReReplyListBiz().ReplyGetReReplyList(parentReplyNo));

        }
        // 본인 확인
        [HttpPost]
        public JsonResult UserCheck(int no)
        {
            if (no > 0)
            {
                return Json(new
                {
                    Email = new ReplyUserCheckBiz().ReplyUerCheck(no)
                });
            }
            return Json(new
            {
                Email = ""
            });

        }
        //댓글 삭제
        [HttpPost]
        public JsonResult DeleteReply(ReplyDeleteRequestModel replyDeleteRequestModel)
        {
            if (replyDeleteRequestModel != null && replyDeleteRequestModel.No > 0 && replyDeleteRequestModel.BoardNo > 0)
            {
                return Json(new
                {
                    Delete = new ReplyDeleteReplyBiz().ReplyDeleteReply(replyDeleteRequestModel.No),
                    ReplyList = new ReplyGetReplyListBiz().GetReplyList(replyDeleteRequestModel.BoardNo),
                });
            }
            return Json(new
            {
                Delete = new ReplyDeleteReplyBiz().ReplyDeleteReply(replyDeleteRequestModel.No)
            });
        }
    }
}
