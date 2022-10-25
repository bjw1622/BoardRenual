using BoardRenual.Biz.Board;
using BoardRenual.Biz.Recommand;
using BoardRenual.Biz.Reply;
using BoardRenual.Models.Models;
using BoardRenual.Models.Models.Request.Board;
using BoardRenual.Models.Models.Request.Page;
using BoardRenual.Models.Models.Request.Recommand;
using BoardRenual.Models.Models.Request.Reply;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace BoardRenual.Controllers
{
    public class BoardController : Controller
    {
        /// <summary>
        /// 쿠키 체크
        /// </summary>
        /// <returns>boolean</returns>
        private bool CookieCheck()
        {
            bool result = false;
            if (Request.Cookies["Email"] != null)
            {
                result = true;
            }
            return result;
        }
        /// <summary>
        /// Board Index페이지
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View(new BoardGetBoardListBiz().GetBoardList());
        }
        /// <summary>
        /// Board Write페이지
        /// </summary>
        /// <returns>View</returns>
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
        /// <summary>
        /// 글쓰기 Http Post
        /// </summary>
        /// <param name="boardWriteRequestModel"></param>
        /// <returns>int boardNo</returns>
        [HttpPost]
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
        /// <summary>
        /// 첨부파일 로컬 저장
        /// </summary>
        /// <param name="Formdata"></param>
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
        /// <summary>
        /// Board 상세 페이지
        /// </summary>
        /// <param name="no"></param>
        /// <returns>View</returns>
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
        /// <summary>
        /// Board 삭제
        /// </summary>
        /// <param name="no"></param>
        /// <returns>boolean</returns>
        [HttpPost]
        public JsonResult Delete(int no)
        {
            if (no > 0)
            {
                return Json(new BoardDeleteBoardBiz().DeleteBoard(no));
            }
            return Json(new BoardDeleteBoardBiz().DeleteBoard(no));
        }
        /// <summary>
        /// Board 수정
        /// </summary>
        /// <param name="boardUpdateRequestModel"></param>
        /// <returns>boolean</returns>
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
        /// <summary>
        /// Board Index 페이징
        /// </summary>
        /// <param name="pageRequestModel"></param>
        /// <returns>int result</returns>
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
        /// <summary>
        /// Board Index 검색 + 페이징
        /// </summary>
        /// <param name="findAndPageRequestModel"></param>
        /// <returns>int result</returns>
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
        /// <summary>
        /// Board Detail 추천
        /// </summary>
        /// <param name="recommandInfoRequestModel"></param>
        /// <returns>int flag</returns>
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
        /// <summary>
        /// Board Detail 댓글,답글 작성
        /// </summary>
        /// <param name="replyWriteRequestModel"></param>
        /// <returns>bool writeResult</returns>
        [HttpPost]
        public JsonResult WriteReply(ReplyWriteRequestModel replyWriteRequestModel)
        {
            bool writeResult = false;
            List<ReplyModel> replyList = null;
            if (replyWriteRequestModel != null && replyWriteRequestModel.BoardNo > 0 && replyWriteRequestModel.ParentReplyNo >= 0
                && !(string.IsNullOrEmpty(replyWriteRequestModel.Content)) && !(string.IsNullOrEmpty(replyWriteRequestModel.Email)))
            {
                writeResult = new ReplyWriteBiz().ReplyWrite(replyWriteRequestModel);
                replyList = new ReplyGetReplyListBiz().GetReplyList(replyWriteRequestModel.BoardNo);
            }
            return Json(new
            {
                WriteResult = writeResult,
                ReplyList = replyList,
            });
        }
        /// <summary>
        /// Board Detail 답글 불러오기
        /// </summary>
        /// <param name="parentReplyNo"></param>
        /// <returns>List<ReplyModel></returns>
        // 답글 불러오기
        [HttpPost]
        public JsonResult GetReReplyList(int parentReplyNo)
        {
            List<ReplyModel> replyModelList = null;
            if (parentReplyNo > 0)
            {
                replyModelList = new ReplyGetReReplyListBiz().ReplyGetReReplyList(parentReplyNo);
            }
            return Json(replyModelList);

        }
        /// <summary>
        /// Board Detail 삭제 권한 본인 체크
        /// </summary>
        /// <param name="no"></param>
        /// <returns>bool</returns>
        // 본인 확인
        [HttpPost]
        public JsonResult UserCheck(int no)
        {
            string email = "";
            if (no > 0)
            {
                email = new ReplyUserCheckBiz().ReplyUerCheck(no);
            }
            return Json(email);

        }
        /// <summary>
        /// Board Detail 댓글 삭제
        /// </summary>
        /// <param name="replyDeleteRequestModel"></param>
        /// <returns>bool</returns>
        [HttpPost]
        public JsonResult DeleteReply(ReplyDeleteRequestModel replyDeleteRequestModel)
        {
            bool delete = false;
            List<ReplyModel> replyList = null;
            if (replyDeleteRequestModel != null && replyDeleteRequestModel.No > 0 && replyDeleteRequestModel.BoardNo > 0)
            {
                delete = new ReplyDeleteReplyBiz().ReplyDeleteReply(replyDeleteRequestModel.No);
                replyList = new ReplyGetReplyListBiz().GetReplyList(replyDeleteRequestModel.BoardNo);
            }
            return Json(new
            {
                Delete = delete,
                ReplyList = replyList,
            });
        }
    }
}
