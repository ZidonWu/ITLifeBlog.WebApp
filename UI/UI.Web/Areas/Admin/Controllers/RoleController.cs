using BLL.Contract;
using BLL.Service.Service.RoleSer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Web.Areas.Admin.Models;

namespace UI.Web.Areas.Admin.Controllers
{
    public class RoleController : BaseController
    {
        private IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        // GET: Admin/Role
        public ActionResult Index()
        {
            ViewData["result"] = GetRoleList();
            return View();
        }

        public ActionResult RoleAdd()   
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAdd(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                Role role = new Role()
                {
                    Name = roleViewModel.Name,
                    Description = roleViewModel.Description
                };
                _roleService.Add(role);
            }
            return RedirectToAction("/RoleAdd");
        }

        public IEnumerable<Role> GetRoleList()
        {
            var result = _roleService.FindList();
            if (result == null)
            {
                return null;
            }
            return result;
        }
    }
}