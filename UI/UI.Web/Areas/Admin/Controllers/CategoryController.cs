using BLL.Contract;
using BLL.Service.Service.CategorySer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Web.Areas.Admin.Models;

namespace UI.Web.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            ViewData["result"] = GetCategoryList();
            return View();
        }

        public ActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CategoryAdd(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category()
                {
                    Name = categoryViewModel.Name,
                    Description = categoryViewModel.Description,
                    Order = categoryViewModel.Order
                };
                _categoryService.Add(category);
            }
            return RedirectToAction("/CategoryAdd");
        }

        public IEnumerable<Category> GetCategoryList()
        {
            var result = _categoryService.FindList();
            if (result == null)
            {
                return null;
            }
            return result;
        }
    }
}