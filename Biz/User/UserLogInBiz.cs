using BoardRenual.Models.OrginalModel.User;
using BoardRenual.Models.RequestModel.User;
using BoardRenual.Repository;

namespace BoardRenual.Biz.User
{
    public class UserLogInBiz
    {
        public UserModel UserSignUp(UserLogInModel signUpEntity)
        {
            UserModel userModel = new UserModel();
            userModel.Email = signUpEntity.Email;
            userModel.Pw = signUpEntity.Pw;
            return new UserRepository().SignIn(userModel, new Connection());
        }
    }
}
