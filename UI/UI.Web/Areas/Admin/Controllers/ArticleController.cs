using BLL.Contract;
using BLL.Service.Service.ArticleSer;
using BLL.Service.Service.CategorySer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using UI.Web.Areas.Admin.Models;
using UI.Web.Areas.Admin.Utility;

namespace UI.Web.Areas.Admin.Controllers
{
    public class ArticleController : BaseController
    {
        private IArticleService _articleService;
        private ICategoryService _categoryService;

        public ArticleController(IArticleService articleService, ICategoryService categoryService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            ViewData["result"] = GetArticleList();
            return View();
        }

        public ActionResult ArticleAdd()
        {
            List<SelectListItem> categoryItems = new List<SelectListItem>();
            var result = _categoryService.FindList();
            foreach (var item in result)
            {
                categoryItems.Add(new SelectListItem() { Value = item.Id.ToString(), Text = item.Name });
            }
            ViewData["CategoryId"] = categoryItems;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult ArticleAdd(ArticleViewModel articleViewModel)
        {
            if (ModelState.IsValid)
            {
                var article = new Article()
                {
                    Title = articleViewModel.Title,
                    Description = articleViewModel.Description,
                    Content = articleViewModel.Content,
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")),
                    CommentNum = 0,
                    IsPublish = true,
                    ReadNum = 0,
                    Stars = 0,
                    AccountId = Convert.ToInt32(CurrentUser.UserId),
                    CategoryId = articleViewModel.CategoryId
                };
                _articleService.Add(article);
                var result = _categoryService.Find(articleViewModel.CategoryId);
                result.Count += 1;
                _categoryService.Update(result);
            }
            return RedirectToAction("/ArticleAdd");
        }

        [HttpGet]
        public ActionResult ArticleUpdate(int id)
        {
            Session["id"] = id;
            //ListModel model = new ListModel();
            Article article = new Article();
            article = _articleService.Find(id);
            ArticleViewModel articleViewModel = new ArticleViewModel();
            articleViewModel = Mapper<ArticleViewModel, Article>(article); ;
            return View(articleViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult ArticleUpdate(ArticleViewModel articleViewModel)
        {
            if (ModelState.IsValid)
            {
                var article = _articleService.Find(Convert.ToInt32(Session["id"]));
                article.Title = articleViewModel.Title;
                article.Description = articleViewModel.Description;
                article.Content = articleViewModel.Content;
                _articleService.Update(article);
            }
            return RedirectToAction("/Index");
        }

        public ActionResult ArticleDelete(int id)
        {
            Article article = new Article();
            var result =_articleService.Delete(id,article);
            return RedirectToAction("/Index");
        }

        public IEnumerable<Article> GetArticleList()
        {
            List<Article> article = new List<Article>();
            if (CurrentUser.RoleId == "1")
            {
                article = _articleService.FindList().ToList();
            }
            else
            {
                article = _articleService.FindListByAccountId(CurrentUser.UserId).ToList();
            }       
            if (article == null)
            {
                return null;
            }
            return article;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ArticleViewModel"></typeparam>
        /// <typeparam name="Article"></typeparam>
        /// <param name="article"></param>
        /// <returns></returns>
        public static ArticleViewModel Mapper<ArticleViewModel, Article>(Article article)
        {
            ArticleViewModel articleViewModel = Activator.CreateInstance<ArticleViewModel>();
            try
            {
                var sType = article.GetType();
                var dType = typeof(ArticleViewModel);
                foreach (PropertyInfo sP in sType.GetProperties())
                {
                    foreach (PropertyInfo dP in dType.GetProperties())
                    {
                        if (dP.Name == sP.Name)
                        {
                            dP.SetValue(articleViewModel, sP.GetValue(article));
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return articleViewModel;
        }
    }
}