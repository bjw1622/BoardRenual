using BoardRenual.Models.OrginalModel.User;
using BoardRenual.Models.Request.User;
using BoardRenual.Repository;

namespace BoardRenual.Biz.User
{
    public class UserSignUpBiz
    {
        public bool UserSignUp(UserSignUpRequestModel signUpRequestModel)
        {
            UserOriginalModel userModel = new UserOriginalModel();
            userModel.Email = signUpRequestModel.Email;
            userModel.Pw = signUpRequestModel.Pw;
            userModel.Name = signUpRequestModel.Name;
            userModel.Birth = signUpRequestModel.Birth;
            return new UserRepository().SignUp(userModel);
        }
    }
}