using BoardRenual.Models.OrginalModel.User;
using BoardRenual.Models.RequestModel.User;
using BoardRenual.Repository;

namespace BoardRenual.Biz.User
{
    public class EmailCheckBiz : UserRepository
    {
        public int UserSignUp(UserEmailCheckModel userEmailCheck)
        {
            UserEntity userEntity = new UserEntity();
            userEntity.Email = userEmailCheck.Email;
            return EmailCheck(userEntity);
        }
    }
}