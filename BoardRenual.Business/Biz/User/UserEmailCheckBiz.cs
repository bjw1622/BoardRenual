using BoardRenual.Models.Models.OrginalModel.User;
using BoardRenual.Models.Models.Request.User;
using BoardRenual.Repository;

namespace BoardRenual.Biz.User
{
    public class UserEmailCheckBiz
    {
        public int EmailCheck(UserEmailCheckRequestModel userEmailCheck)
        {
            UserOriginalModel userModel = new UserOriginalModel();
            userModel.Email = userEmailCheck.Email;
            return new UserRepository().EmailCheck(userModel);
        }
    }
}