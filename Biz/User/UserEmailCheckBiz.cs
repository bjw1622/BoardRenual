using BoardRenual.Models.OrginalModel.User;
using BoardRenual.Models.RequestModel.User;
using BoardRenual.Repository;
using System.Data.SqlClient;

namespace BoardRenual.Biz.User
{
    public class UserEmailCheckBiz
    {
        public int UserSignUp(UserEmailCheckModel userEmailCheck)
        {
            UserModel userEntity = new UserModel();
            UserRepository userRepository = new UserRepository();
            userEntity.Email = userEmailCheck.Email;
            
            Connection connection = new Connection();
            SqlConnection con = connection.ConOpen();
            return userRepository.EmailCheck(userEntity,con);
        }
    }
}