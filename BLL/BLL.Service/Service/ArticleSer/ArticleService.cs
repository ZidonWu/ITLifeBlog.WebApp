using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Contract;

namespace BLL.Service.Service.ArticleSer
{
    public class ArticleService : IArticleService
    {
        private readonly string _url;
        public ArticleService(string url)
        {
            _url = url;
        }

        private string GetTicket()
        {
            var url = _url + "api/Account/Login?name=admin&password=123";
            return WebApiHelper.GetEntity<Account>(url).Ticket;
        }

        public OperResult Add(Article article)
        {
            var ticket = GetTicket();
            var addr = _url + "api/Article/Add";
            return WebApiHelper.PostEntity<Article>(addr, article, ticket);
        }

        public int Count()
        {
            var ticket = GetTicket();
            var addr = _url + "api/Article/GetCount";
            return WebApiHelper.GetEntity<int>(addr, ticket);
        }

        public int CountByUserName(string name) 
        {
            var ticket = GetTicket();
            var addr = _url + "api/Article/GetCountByUserName?name={0}";
            addr = string.Format(addr, name);
            return WebApiHelper.GetEntity<int>(addr, ticket);
        }

        public OperResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public OperResult Delete(Article entity)
        {
            throw new NotImplementedException();
        }

        public OperResult Delete(Expression<Func<Article, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Article Find(int id)
        {
            throw new NotImplementedException();
        }

        public Article Find(Expression<Func<Article, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Article> FindList()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Article> FindList(Expression<Func<Article, bool>> where)
        {
            throw new NotImplementedException();
        }

        public OperResult Update(int id)
        {
            throw new NotImplementedException();
        }

        public OperResult Update(Article entity)
        {
            throw new NotImplementedException();
        }

        public OperResult Update(Expression<Func<Article, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Article> FindListByUserName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
