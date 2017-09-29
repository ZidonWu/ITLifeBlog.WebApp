using BLL.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.Service.UserSer
{
    public interface IUserService
    {
        IEnumerable<User> FindAllList();

    }
}
