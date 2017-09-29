using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Contract;

namespace BLL.Service.Service.UserSer
{
    public class UserService : IUserService
    {
        private readonly string _url;
        public UserService(string url)
        {
            _url = url;
        }
            
        public IEnumerable<User> FindAllList()
        {
            throw new NotImplementedException();
        }
    }
}
