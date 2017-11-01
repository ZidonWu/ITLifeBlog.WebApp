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
    public class ArticleController : Controller
    {
        private IArticleService _articleService;
        private ICategoryService _categoryService;
        private IAccountService _accountService;

        public ArticleController(IArticleService articleService,ICategoryService categoryService,IAccountService accountService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _accountService = accountService;
        }

        public ActionResult Index(int? pageIndex, string where = "")
        {
            Paging<Article> page = new Paging<Article>();
            page.PageIndex = pageIndex == null ? 1 : pageIndex.Value;
            page.PageSize = 10;
            page.Items = _articleService.FindPageList(pageIndex, "").ToList();
            page.TotalNumber = _articleService.FindList().Count();
            #region 构造分页
            //构造标签
            int PageCount = page.TotalNumber;
            int PageSize = page.PageSize;
            int totalPage = (PageCount + PageSize - 1) / PageSize;
            string urlhead = "/Web/Article/Index/" + pageIndex + "?pageindex=";
            string pages = "";
            //string pages = "<li><a href='" + urlhead + "1" + "'>First Page</a></li>"; ;
            if (page.PageIndex == 1)
            {
                pages += "<li class='disabled'><a href='#' style='width:125px;'>Previous Page </a></li>";
            }
            else
            {
                pages += "<li ><a href='" + urlhead + (page.PageIndex - 1) + "' style='width:125px;'>Previous Page</a></li>";
            }
            if (page.PageIndex == totalPage)
            {
                pages += "<li class='disabled'><a href='#' style='width:125px;'>Next Page</a></li>";
            }
            else
            {
                pages += "<li ><a href='" + urlhead + (page.PageIndex + 1) + "' style='width:125px;'>Next Page</a></li>";
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

        [HttpGet]
        public ActionResult ArticleDetail(int id)
        {
            var model = new ListModel();
            model.Article = _articleService.Find(id);
            model.Category = _categoryService.Find(model.Article.CategoryId);
            model.Account = _accountService.FindById(model.Article.AccountId);
            model.ArticleModels2 = _articleService.FindList().OrderByDescending(t => t.ReadNum).ToList();
            model.CategoryModels = _categoryService.FindList().OrderBy(t => t.Order).ToList();
            model.AccountModels = _accountService.FindList().Where(t => t.RoleId == 2).ToList();
            model.Article.ReadNum += 1;
            _articleService.Update(model.Article);
            return View(model);
        }

        //[HttpGet]
        //public ActionResult ArticleDetail(string guid)
        //{
        //    var model = new ListModel();
        //    model.Article = _articleService.Find(guid);
        //    model.Category = _categoryService.Find(model.Article.CategoryId);
        //    model.Account = _accountService.FindById(model.Article.AccountId);
        //    model.ArticleModels2 = _articleService.FindList().OrderByDescending(t => t.ReadNum).ToList();
        //    model.CategoryModels = _categoryService.FindList().OrderBy(t => t.Order).ToList();
        //    model.AccountModels = _accountService.FindList().Where(t => t.RoleId == 2).ToList();
        //    model.Article.ReadNum += 1;
        //    _articleService.Update(model.Article);
        //    return View(model);
        //}

        [HttpGet]
        public ActionResult ArticleCategory(int id)
        {
            Session["id"] = id;
            return RedirectToAction("/ArticleCategory2/" + id);
        }

        public ActionResult ArticleCategory2(int? pageIndex, int id = -1)
        {
            var id2 = Convert.ToInt32(Session["id"]);
            Paging<Article> page = new Paging<Article>();
            page.PageIndex = pageIndex == null ? 1 : pageIndex.Value;
            page.PageSize = 10;
            page.Items = _articleService.FindPageListByCategoryId(pageIndex, id2).Where(t => t.IsDeleted == false).ToList();
            page.TotalNumber = _articleService.FindList().Where(t => t.CategoryId == id2).Count();
            #region 构造分页
            //构造标签
            int PageCount = page.TotalNumber;
            int PageSize = page.PageSize;
            int totalPage = (PageCount + PageSize - 1) / PageSize;
            string urlhead = "/Web/Article/ArticleCategory/" + pageIndex + "?pageindex=";
            string pages = "";
            //string pages = "<li><a href='" + urlhead + "1" + "'>First Page</a></li>"; ;
            if (page.PageIndex == 1)
            {
                pages += "<li class='disabled'><a href='#' style='width:125px;'>Previous Page </a></li>";
            }
            else
            {
                pages += "<li ><a href='" + urlhead + (page.PageIndex - 1) + "' style='width:125px;'>Previous Page</a></li>";
            }
            if (page.PageIndex == totalPage)
            {
                pages += "<li class='disabled'><a href='#' style='width:125px;'>Next Page</a></li>";
            }
            else
            {
                pages += "<li ><a href='" + urlhead + (page.PageIndex + 1) + "' style='width:125px;'>Next Page</a></li>";
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
            model.AccountModels = _accountService.FindList().ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult ArticleAccount(int id)
        {
            Session["id"] = id;
            return RedirectToAction("/ArticleAccount2/" + id);
        }

        public ActionResult ArticleAccount2(int? pageIndex, int id = -1)    
        {
            var id2 = Convert.ToInt32(Session["id"]);
            Paging<Article> page = new Paging<Article>();
            page.PageIndex = pageIndex == null ? 1 : pageIndex.Value;
            page.PageSize = 10;
            page.Items = _articleService.FindPageListByAccountId(pageIndex, id2).Where(t => t.IsDeleted == false).ToList();
            page.TotalNumber = _articleService.FindList().Where(t => t.AccountId == id2).Count();
            #region 构造分页
            //构造标签
            int PageCount = page.TotalNumber;
            int PageSize = page.PageSize;
            int totalPage = (PageCount + PageSize - 1) / PageSize;
            string urlhead = "/Web/Article/ArticleAccount/" + pageIndex + "?pageindex=";
            string pages = "";
            //string pages = "<li><a href='" + urlhead + "1" + "'>First Page</a></li>"; ;
            if (page.PageIndex == 1)
            {
                pages += "<li class='disabled'><a href='#' style='width:125px;'>Previous Page </a></li>";
            }
            else
            {
                pages += "<li ><a href='" + urlhead + (page.PageIndex - 1) + "' style='width:125px;'>Previous Page</a></li>";
            }
            if (page.PageIndex == totalPage)
            {
                pages += "<li class='disabled'><a href='#' style='width:125px;'>Next Page</a></li>";
            }
            else
            {
                pages += "<li ><a href='" + urlhead + (page.PageIndex + 1) + "' style='width:125px;'>Next Page</a></li>";
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
            model.AccountModels = _accountService.FindList().ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Search(SearchModel searchModel)
        {
            string title = searchModel.Title;
            Session["title"] = title;
            return RedirectToAction("/ArticleSearch/");
        }

        [HttpGet]
        public ActionResult ArticleSearch(int? pageIndex, string where = "")
        {
            var search = Session["title"].ToString();
            Paging<Article> page = new Paging<Article>();
            page.PageIndex = pageIndex == null ? 1 : pageIndex.Value;
            page.PageSize = 10;
            page.Items = _articleService.FindPageList(pageIndex, "").Where(x => x.Title.Contains(search)).ToList();
            page.TotalNumber = _articleService.FindList().Where(x=>x.Title.Contains(search)).Count();
            #region 构造分页
            //构造标签
            int PageCount = page.TotalNumber;
            int PageSize = page.PageSize;
            int totalPage = (PageCount + PageSize - 1) / PageSize;
            string urlhead = "/Web/Article/Index/" + pageIndex + "?pageindex=";
            string pages = "";
            //string pages = "<li><a href='" + urlhead + "1" + "'>First Page</a></li>"; ;
            if (page.PageIndex == 1)
            {
                pages += "<li class='disabled'><a href='#' style='width:125px;'>Previous Page </a></li>";
            }
            else
            {
                pages += "<li ><a href='" + urlhead + (page.PageIndex - 1) + "' style='width:125px;'>Previous Page</a></li>";
            }
            if (page.PageIndex == totalPage)
            {
                pages += "<li class='disabled'><a href='#' style='width:125px;'>Next Page</a></li>";
            }
            else
            {
                pages += "<li ><a href='" + urlhead + (page.PageIndex + 1) + "' style='width:125px;'>Next Page</a></li>";
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
            model.AccountModels = _accountService.FindList().ToList();
            return View(model);
        }

    }
}