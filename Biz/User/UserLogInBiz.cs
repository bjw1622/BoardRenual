using BoardRenual.Models.OrginalModel.User;
using BoardRenual.Models.RequestModel.User;
using BoardRenual.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BoardRenual.Biz.User
{
    public class UserLogInBiz
    {
        public UserModel UserSignUp(UserLogInModel signUpEntity)
        {
            UserModel userModel = new UserModel();
            UserRepository userRepository = new UserRepository();
            userModel.Email = signUpEntity.Email;
            userModel.Pw = signUpEntity.Pw;

            Connection connection = new Connection();
            return userRepository.SignIn(userModel, connection);
        }
    }
}
