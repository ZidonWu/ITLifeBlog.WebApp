using BLL.Contract;
using BLL.Service.Service.AccountSer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Web.Areas.Admin.Models;

namespace UI.Web.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // GET: Admin/Account
        public ActionResult Index()
        {
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

        public OperResult LoginResult(string name, string password)
        {
            OperResult result = new OperResult();
            var account = _accountService.GetByName(name);
            if (account == null)
            {
                result.Code = 2;
                result.Message = "帐号为:【" + name + "】的管理员不存在";
            }
            else if (account.Password == password)
            {
                result.Code = 1;
                result.Message = "验证通过";
            }
            else
            {
                result.Code = 3;
                result.Message = "密码错误";
            }
            return result;
        }
    }
}