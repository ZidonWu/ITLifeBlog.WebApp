using BLL.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.Service.AccountSer
{
    public interface IAccountService
    {
        string Login(string name, string password);

        OperResult Add(Account account);

        IEnumerable<Account> GetAllList();

        Account GetById(int id);

        Account GetByName(string name);

        OperResult UpdateById(Account account, int id);

        OperResult UpdateByName(Account account, string name);

        OperResult DeleteById(int id);

        OperResult DeleteByName(string name);
    }
}
