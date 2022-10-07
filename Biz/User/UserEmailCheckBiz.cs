using BoardRenual.Models.OrginalModel.User;
using BoardRenual.Models.RequestModel.User;
using BoardRenual.Repository;

namespace BoardRenual.Biz.User
{
    public class UserEmailCheckBiz
    {
        public int EmailCheck(UserEmailCheckModel userEmailCheck)
        {
            UserModel userModel = new UserModel();
            userModel.Email = userEmailCheck.Email;
            Connection connection = new Connection();
            return new UserRepository().EmailCheck(userModel, connection);
        }
    }
}