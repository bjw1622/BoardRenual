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
    public class UserSignUpBiz
    {
        public int UserSignUp(UserSignUpModel signUpModel)
        {
            UserModel userModel = new UserModel();
            UserRepository userRepository = new UserRepository();

            userModel.Email = signUpModel.Email;
            userModel.Pw = signUpModel.Pw;
            userModel.Name = signUpModel.Name;
            userModel.Birth = signUpModel.Birth;
            
            Connection connection = new Connection();
            return userRepository.SignUp(userModel, connection);
        }
    }
}