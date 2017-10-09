using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Contract;
using System.Web.Script.Serialization;

namespace BLL.Service.Service.AccountSer
{
    public class AccountService : IAccountService
    {
        private readonly string _url;

        public AccountService(string url)
        {
            _url = url;
        }

        public string GetTicket(string name, string password)
        {
            var addr = _url + "api/Account/Login?name={0}&password={1}";
            addr = string.Format(addr, name, password);
            SaveTicket.Ticket = WebApiHelper.GetEntity<Account>(addr).Ticket;
            return SaveTicket.Ticket;
        }

        public string Login(string name, string password)
        {
            var addr = _url + "api/Account/Login?name={0}&password={1}";
            addr = string.Format(addr, name, password);
            return WebApiHelper.GetEntity<Account>(addr).Ticket;
        }

        public OperResult Add(Account account)
        {
            var ticket = SaveTicket.Ticket;
            var addr = _url + "api/Account/Add";
            return WebApiHelper.PostEntity<Account>(addr, account, ticket);
        }

        public Account FindByName(string name)
        {
            var ticket = SaveTicket.Ticket;
            var addr = _url + "api/Account/GetByName?name={0}";
            addr = string.Format(addr, name);
            return WebApiHelper.GetEntity<Account>(addr, ticket);
        }

        public IEnumerable<Account> FindList()  
        {
            var ticket = SaveTicket.Ticket;
            var addr = _url + "api/Account/GetAllList";
            return WebApiHelper.GetEntitys<Account>(addr, ticket);
        }

        public Account FindById(int id)
        {
            var ticket = SaveTicket.Ticket;
            var addr = _url + "api/Account/GetById/{0}";
            addr = string.Format(addr, id);
            return WebApiHelper.GetEntity<Account>(addr, ticket);
        }

        public OperResult UpdateById(int id, Account account)
        {
            var ticket = SaveTicket.Ticket;
            var addr = _url + "api/Account/UpdateById/{0}";
            addr = string.Format(addr, id);
            return WebApiHelper.PostEntity<Account>(addr, account, ticket);
        }

        public OperResult UpdateByName(string name, Account account)
        {
            var ticket = SaveTicket.Ticket;
            var addr = _url + "api/Account/UpdateById?name={0}";
            addr = string.Format(addr, name);
            return WebApiHelper.PostEntity<Account>(addr, account, ticket);
        }

        public OperResult DeleteById(int id)
        {
            var ticket = SaveTicket.Ticket;
            var addr = _url + "api/Account/DeleteById/{0}";
            addr = string.Format(addr, id);
            return WebApiHelper.GetEntity<OperResult>(addr, ticket);
        }

        public OperResult DeleteByName(string name)
        {
            var ticket = SaveTicket.Ticket;
            var addr = _url + "api/Account/DeleteByName?name={0}";
            addr = string.Format(addr, name);
            return WebApiHelper.GetEntity<OperResult>(addr, ticket);
        }

        public OperResult UpdatePassword(int id, Account account)    
        {
            var ticket = SaveTicket.Ticket;
            var addr = _url + "api/Account/UpdatePassword/{0}";
            addr = string.Format(addr, id);
            return WebApiHelper.PostEntity<Account>(addr, account, ticket);
        }
    }
}
