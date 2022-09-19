using BoardRenual.Models.OrginalModel.User;
using BoardRenual.Models.RequestModel.User;
using BoardRenual.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardRenual.Biz.User
{
    public class UserSignUpBiz : UserRepository
    {
        public bool UserSignUp(UserSignUpModel signUpModel)
        {
            UserEntity userEntity = new UserEntity();
            userEntity.Email = signUpModel.Email;
            userEntity.Pw = signUpModel.Pw;
            userEntity.Name = signUpModel.Name;
            userEntity.Birth = signUpModel.Birth;
            return SignUp(userEntity);
        }
    }
}