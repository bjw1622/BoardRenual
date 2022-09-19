using BoardRenual.Models.OrginalModel.User;
using BoardRenual.Models.RequestModel.User;
using BoardRenual.Repository;

namespace BoardRenual.Biz.User
{
    public class UserEmailCheckBiz : UserRepository
    {
        public int UserSignUp(UserEmailCheckModel userEmailCheck)
        {
            UserModel userEntity = new UserModel();
            userEntity.Email = userEmailCheck.Email;
            return EmailCheck(userEntity);
        }
    }
}