using BoardRenual.Models.OrginalModel.User;
using BoardRenual.Models.RequestModel.User;
using BoardRenual.Repository;
using System.Data.SqlClient;

namespace BoardRenual.Biz.User
{
    public class UserEmailCheckBiz
    {
        public int EmailCheck(UserEmailCheckModel userEmailCheck)
        {
            UserModel userModel = new UserModel();
            UserRepository userRepository = new UserRepository();
            userModel.Email = userEmailCheck.Email;
            
            Connection connection = new Connection();
            return userRepository.EmailCheck(userModel, connection);
        }
    }
}