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
        public bool UserSignUp(UserSignUpModel signUpModel)
        {
            UserModel userEntity = new UserModel();
            UserRepository userRepository = new UserRepository();
            
            userEntity.Email = signUpModel.Email;
            userEntity.Pw = signUpModel.Pw;
            userEntity.Name = signUpModel.Name;
            userEntity.Birth = signUpModel.Birth;
            
            Connection connection = new Connection();
            SqlConnection con = connection.ConOpen();
            return userRepository.SignUp(userEntity,con);
        }
    }
}