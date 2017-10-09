using BLL.Contract;
using BLL.Service.Service.AccountSer;
using BLL.Service.Service.ArticleSer;
using BLL.Service.Service.CategorySer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Web.Areas.Web.Models;

namespace UI.Web.Areas.Web.Controllers
{
    public class HomeController : Controller
    {
        private IArticleService _articleService;
        private ICategoryService _categoryService;
        private IAccountService _accountService;

        public HomeController(IArticleService articleService, ICategoryService categoryService,IAccountService accountService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _accountService = accountService;
        }
        // GET: Web/Home
        public ActionResult Index(int? pageIndex, string where = "")
        {
            Paging<Article> page = new Paging<Article>();
            page.PageIndex = pageIndex == null ? 1 : pageIndex.Value;
            page.PageSize = 10;
            page.Items = _articleService.FindPageList(pageIndex, "").Where(t => t.IsDeleted == false).ToList();
            page.TotalNumber = _articleService.Count();
            #region 构造分页
            //构造标签
            int PageCount = page.TotalNumber;
            int PageSize = page.PageSize;
            int totalPage = (PageCount + PageSize - 1) / PageSize;
            string urlhead = "/Web/Home/Index/" + pageIndex + "?pageindex=";
            string pages = "";
            //string pages = "<li><a href='" + urlhead + "1" + "'>First Page</a></li>"; ;
            if (page.PageIndex == 1)
            {
                pages += "<li class='disabled'><a href='#'>Previous Page </a></li>";
            }
            else
            {
                pages += "<li ><a href='" + urlhead + (page.PageIndex - 1) + "'>Previous Page</a></li>";
            }
            if (page.PageIndex == totalPage)
            {
                pages += "<li class='disabled'><a href='#'>Next Page</a></li>";
            }
            else
            {
                pages += "<li ><a href='" + urlhead + (page.PageIndex + 1) + "'>Next Page</a></li>";
            }
            //pages += "<li ><a href='" + urlhead + totalPage + "'>End Page</a></li>";
            ViewBag.Page = pages;
            ViewBag.PageIndex = page.PageIndex;
            ViewBag.PageCount = totalPage;
            #endregion

            var model = new ListModel();
            model.ArticleModels = page.Items.ToList();
            model.ArticleModels2 = _articleService.FindList().OrderByDescending(t => t.ReadNum).ToList();
            model.CategoryModels = _categoryService.FindList().OrderBy(t => t.Order).ToList();
            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}