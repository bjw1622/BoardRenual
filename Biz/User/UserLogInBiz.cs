using BoardRenual.Models.OrginalModel.User;
using BoardRenual.Models.Request.User;
using BoardRenual.Repository;

namespace BoardRenual.Biz.User
{
    public class UserLogInBiz
    {
        public UserOriginalModel SignIn(UserLogInRequestModel signUpEntity)
        {
            UserOriginalModel userModel = new UserOriginalModel();
            userModel.Email = signUpEntity.Email;
            userModel.Pw = signUpEntity.Pw;
            return new UserRepository().SignIn(userModel);
        }
    }
}
