using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using BLL.Service.Service.AccountSer;
using BLL.Service.Service.ArticleSer;
using BLL.Service.Service.UserSer;
using BLL.Service.Service.RoleSer;
using BLL.Service.Service.CategorySer;

namespace UI.Web
{
    public static class UnityConfig
    {
        static string _url = Properties.Settings.Default.WebApiUrl;
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IAccountService, AccountService>(new InjectionConstructor(_url));
            container.RegisterType<IArticleService, ArticleService>(new InjectionConstructor(_url));
            container.RegisterType<IUserService, UserService>(new InjectionConstructor(_url));
            container.RegisterType<IRoleService, RoleService>(new InjectionConstructor(_url));
            container.RegisterType<ICategoryService, CategoryService>(new InjectionConstructor(_url));
            //container.RegisterInstance<AccountService>(new AccountService(_url));
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}