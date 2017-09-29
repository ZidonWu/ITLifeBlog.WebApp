using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using BLL.Service.Service.RoleSer;
using BLL.Contract;
using BLL.Service.Service.AccountSer;

namespace BLL.Test
{
    [TestClass]
    public class UnitTest1
    {
        string _url = Properties.Settings.Default.WebApiUrl2;
        private IRoleService _roleService;
        private IAccountService _accountService;

        public UnitTest1()
        {
            _roleService = new RoleService(_url);
            _accountService = new AccountService(_url);
        }

        [TestMethod]
        public void TestMethod1()
        {
            Role role = new Role()
            {
                Name = "普通用户",
                Description = "普通权限"
            };

            _roleService.Add(role);

        }

        [TestMethod]
        public void TestMethod2()
        {
            string name = "admin";
            var account = _accountService.GetByName(name);
            //return account;
            Console.WriteLine(account.Name);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var account = new Account
            {
                Name = "admin",
                Password = "123"
            };
           var result = _accountService.Login(account);
            Console.WriteLine(result);
        }
    }
}
