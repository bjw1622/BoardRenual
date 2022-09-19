using BoardRenual.Models.OrginalModel.User;
using BoardRenual.Models.RequestModel.User;
using BoardRenual.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardRenual.Biz.User
{
    public class UserLogInBiz : UserRepository
    {
        public UserModel UserSignUp(UserLogInModel signUpEntity)
        {
            UserModel userEntity = new UserModel();
            userEntity.Email = signUpEntity.Email;
            userEntity.Pw = signUpEntity.Pw;
            return SignIn(userEntity);
        }
    }
}
