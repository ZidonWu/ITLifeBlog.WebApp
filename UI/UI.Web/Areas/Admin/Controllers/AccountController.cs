using BLL.Contract;
using BLL.Service.Service.AccountSer;
using BLL.Service.Service.RoleSer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Web.Areas.Admin.Models;
using UI.Web.Areas.Admin.Utility;

namespace UI.Web.Areas.Admin.Controllers
{
    public class AccountController : BaseController
    {
        private IAccountService _accountService;
        private IRoleService _roleService;

        public AccountController(IAccountService accountService, IRoleService roleService)
        {
            _accountService = accountService;
            _roleService = roleService;
        }

        public ActionResult Index()
        {
            ViewData["result"] = GetAccountList();
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = LoginResult(loginViewModel.Name, loginViewModel.Password);
                if (result.Code == 1)
                {
                    return RedirectToAction("Index", "Home", new { Areas = "Admin" });
                }
                else if (result.Code == 2) ModelState.AddModelError("Name", result.Message);
                else if (result.Code == 3) ModelState.AddModelError("Password", result.Message);
                else ModelState.AddModelError("", result.Message);
            }
            return View(loginViewModel);
        }

        public ActionResult AccountAdd()
        {
            List<SelectListItem> roleItems = new List<SelectListItem>();
            var result = _roleService.FindList();
            foreach (var item in result)
            {
                roleItems.Add(new SelectListItem() { Value = item.Id.ToString(), Text = item.Name });
            }
            ViewData["RoleId"] = roleItems;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccountAdd(AccountViewModel accountViewModel)
        {
            if (ModelState.IsValid)
            {
                Account account = new Account()
                {
                    Name = accountViewModel.Name,
                    Password = accountViewModel.Password,
                    RoleId = accountViewModel.RoleId
                };
                _accountService.Add(account);
            }
            return RedirectToAction("/AccountAdd");
        }

        public ActionResult UpdatePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdatePassword(AccountViewModel accountViewModel)
        {
            if (ModelState.IsValid)
            {
                Account account = new Account()
                {
                    Password = accountViewModel.Password
                };
                _accountService.UpdatePassword(Convert.ToInt32(CurrentUser.UserId), account);
            }
            return RedirectToAction("/UpdatePassword");
        }

        public OperResult LoginResult(string name, string password)
        {
            OperResult result = new OperResult();
            var result2 = _accountService.GetTicket(name, password);
            var account = _accountService.FindByName(name);
            if (account == null)
            {
                result.Code = 2;
                result.Message = "帐号为:【" + name + "】的管理员不存在";
            }
            else if (account.Password == password)
            {
                result.Code = 1;
                result.Message = "验证通过";
                System.Web.HttpContext.Current.Session["UserId"] = account.Id;
                System.Web.HttpContext.Current.Session["UserName"] = account.Name;
                System.Web.HttpContext.Current.Session["RoleId"] = account.RoleId;
            }
            else
            {
                result.Code = 3;
                result.Message = "密码错误";
            }
            return result;
        }

        public IEnumerable<Account> GetAccountList()
        {
            var result = _accountService.FindList();
            if (result == null)
            {
                return null;
            }
            return result;
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        public ActionResult OutLogin()
        {
            CurrentUser.Exit();
            return RedirectToAction("Login", "Account", new { Areas = "Admin" });
        }
    }
}