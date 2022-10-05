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
        [HttpGet]
        public ActionResult Index()
        {
            if (Request.Cookies["Email"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            return View(new BoardGetBoardListBiz().GetBoardList());
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
            int BoardNo = -1;
            if (boardWriteModel == null)
            {
                return Json(
                    BoardNo
                    );
            }
            if (!(string.IsNullOrEmpty(boardWriteModel.Title)) && !(string.IsNullOrEmpty(boardWriteModel.Content))
                && !(string.IsNullOrEmpty(boardWriteModel.Email)))
            {
                BoardNo = new BoardWriteBiz().WriteBoard(boardWriteModel);
            }
            if (BoardNo != -1)
            {
                UploadFiles(boardWriteModel.FormData);
                new BoardWriteFileBiz().WriteFileBoard(BoardNo, boardWriteModel.FileName);
            }
            return Json(
                new
                {
                    Result = BoardNo,
                }
                );
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
        public ActionResult Detail(int No)
        {
            if (No > 0)
            {
                if (new BoardGetBoardEmailBiz().GetBoardEmail(No).Email == Request.Cookies["Email"].Value)
                {
                    ViewBag.EmailCheck = true;
                }
                else
                {
                    ViewBag.EmailCheck = false;
                }
                ViewBag.RecommandCount = new RecommandGetCountBiz().GetRecommandCount(No);
                ViewBag.FileInfoList = new BoardGetFileInfoBiz().BoardGetFileInfo(No);
                ViewBag.ReplyList = new ReplyGetReplyListBiz().GetReplyList(No);
                return View(new BoardGetBoardDetailBiz().GetBoardDetail(No));
            }
            return RedirectToAction("Index", "Board");

        }
        // 삭제
        [HttpPost]
        public JsonResult Delete(int No)
        {
            if (No > 0)
            {
                return Json(new
                {
                    flag = new BoardDeleteBoardBiz().DeleteBoard(No)
                });
            }
            return Json(new { flag = false });

        }
        // 수정
        [HttpPost]
        public JsonResult Update(BoardUpdateRequestModel boardUpdateRequestModel)
        {
            if (boardUpdateRequestModel == null)
            {
                return Json(new
                {
                    flag = -1
                }
                    );
            }
            if (boardUpdateRequestModel.No > 0 && !(string.IsNullOrEmpty(boardUpdateRequestModel.Title))
                && !(string.IsNullOrEmpty(boardUpdateRequestModel.Content)))
            {
                return Json(new
                {
                    flag = new BoardUpdateBiz().UpdateBoard(boardUpdateRequestModel)
                });
            }
            return Json(new
            {
                flag = -1
            }
                    );
        }
        [HttpGet]
        // 페이징
        public JsonResult IndexPaging(PageRequestModel pageRequestModel)
        {
            if (pageRequestModel == null)
            {
                return Json(new
                {
                    Paging = -1
                }
                    );
            }
            if (pageRequestModel.PageNumber > 0 && pageRequestModel.PageCount > 0)
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
            return Json(new
            {
                Result = new BoardFindAndPageCountRequestBiz().PageAndFindBoardCount(findAndPageRequestModel),
                Paging = new BoardFindAndPageRequestBiz().PageAndFindBoard(findAndPageRequestModel)
            }, JsonRequestBehavior.AllowGet
        );
        }
        // 검색 + 페이징
        [HttpPost]
        public JsonResult Recommand(RecommandInfoRequestModel recommandInfoRequestModel)
        {
            int recommandInfoNum = new RecommandInfoBiz().GetRecommandInfo(recommandInfoRequestModel);
            int flag = -1;
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
            int recommandCount = new RecommandGetCountBiz().GetRecommandCount(recommandInfoRequestModel.Board_No);
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
            return Json(new
            {
                WriteResult = new ReplyWriteBiz().ReplyWrite(replyWriteRequestModel),
                ReplyList = new ReplyGetReplyListBiz().GetReplyList(replyWriteRequestModel.BoardNo),
            }
            );
        }
        // 답글 불러오기
        [HttpPost]
        public JsonResult GetReReplyList(int ParentReplyNo)
        {
            return Json(new
            {
                ReReplyList = new ReplyGetReReplyListBiz().ReplyGetReReplyList(ParentReplyNo)
            });
        }
        // 본인 확인
        [HttpPost]
        public JsonResult UserCheck(int No)
        {
            return Json(new
            {
                Email = new ReplyUserCheckBiz().ReplyUerCheck(No)
            });
        }
        //부모 댓글 삭제 
        public JsonResult DeleteReply(ReplyDeleteRequestModel replyDeleteRequestModel)
        {
            return Json(new
            {
                Delete = new ReplyDeleteReplyBiz().ReplyDeleteReply(replyDeleteRequestModel.No),
                ReplyList = new ReplyGetReplyListBiz().GetReplyList(replyDeleteRequestModel.BoardNo),
            });
        }
    }
}
