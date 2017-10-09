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

        string GetTicket(string name, string password);

        OperResult Add(Account account);

        IEnumerable<Account> FindList();    

        Account FindById(int id);

        Account FindByName(string name);

        OperResult UpdateById(int id, Account account);

        OperResult UpdateByName(string name, Account account);

        OperResult UpdatePassword(int id, Account account);  

        OperResult DeleteById(int id);

        OperResult DeleteByName(string name);
    }
}
