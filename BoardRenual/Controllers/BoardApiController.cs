using BoardRenual.Biz.Board;
using System.Web.Http;

namespace BoardRenual.Controllers
{
    public class BoardApiController : ApiController
    {
        [Route("api/Sample/Test")]
        [HttpGet]
        public IHttpActionResult IndexBoardList()
        {
            var result = new BoardGetBoardListBiz().GetBoardList();
            return Ok(result);
        }
    }
}
