using BoardRenual.Models.OrginalModel.User;
using BoardRenual.Models.RequestModel.User;
using BoardRenual.Repository;

namespace BoardRenual.Biz.User
{
    public class UserSignUpBiz
    {
        public bool UserSignUp(UserSignUpModel signUpModel)
        {
            UserModel userModel = new UserModel();
            userModel.Email = signUpModel.Email;
            userModel.Pw = signUpModel.Pw;
            userModel.Name = signUpModel.Name;
            userModel.Birth = signUpModel.Birth;
            Connection connection = new Connection();
            return new UserRepository().SignUp(userModel, connection);
        }
    }
}