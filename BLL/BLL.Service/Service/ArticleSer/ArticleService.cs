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

        public OperResult Add(Article article)
        {
            var ticket = SaveTicket.Ticket;
            var addr = _url + "api/Article/Add";
            return WebApiHelper.PostEntity<Article>(addr, article, ticket);
        }

        public int Count()
        {
            var ticket = SaveTicket.Ticket;
            var addr = _url + "api/Article/GetCount";
            return WebApiHelper.GetEntity<int>(addr, ticket);
        }

        public int CountByAccountName(string accountName)
        {
            var ticket = SaveTicket.Ticket;
            var addr = _url + "api/Article/GetCountByAccountName?accountName={0}";
            addr = string.Format(addr, accountName);
            return WebApiHelper.GetEntity<int>(addr, ticket);
        }

        public OperResult Delete(int id, Article article)
        {
            var ticket = SaveTicket.Ticket;
            var addr = _url + "api/Article/DeleteById/{0}";
            addr = string.Format(addr, id);
            return WebApiHelper.PostEntity<Article>(addr, article, ticket);
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
            var ticket = SaveTicket.Ticket;
            var addr = _url + "api/Article/GetById/{0}";
            addr = string.Format(addr, id);
            return WebApiHelper.GetEntity<Article>(addr, ticket);
        }

        public Article Find(string guid)
        {
            var ticket = SaveTicket.Ticket;
            var addr = _url + "api/Article/GetByGuid/{0}";
            addr = string.Format(addr, guid);
            return WebApiHelper.GetEntity<Article>(addr, ticket);
        }

        public Article Find(Expression<Func<Article, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> FindList()
        {
            var ticket = SaveTicket.Ticket;
            var addr = _url + "api/Article/GetAllList";
            return WebApiHelper.GetEntitys<Article>(addr, ticket);
        }

        public IEnumerable<Article> FindList(Expression<Func<Article, bool>> where)
        {
            throw new NotImplementedException();
        }

        public OperResult Update(int id)
        {
            throw new NotImplementedException();
        }

        public OperResult Update(Article article)
        {
            var ticket = SaveTicket.Ticket;
            var addr = _url + "api/Article/Update";
            return WebApiHelper.PostEntity<Article>(addr, article, ticket);
        }

        public OperResult Update(Expression<Func<Article, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> FindListByAccountName(string accountName)
        {
            var ticket = SaveTicket.Ticket;
            var addr = _url + "api/Article/GetListByAccountName?accountName={0}";
            addr = string.Format(addr, accountName);
            return WebApiHelper.GetEntitys<Article>(addr, ticket);
        }

        public IEnumerable<Article> FindListByAccountId(string accountId)
        {
            var ticket = SaveTicket.Ticket;
            var addr = _url + "api/Article/GetListByAccountId?accountId={0}";
            addr = string.Format(addr, accountId);
            return WebApiHelper.GetEntitys<Article>(addr, ticket);
        }

        public IEnumerable<Article> FindPageList(int? pageIndex, string where = "")
        {
            var ticket = SaveTicket.Ticket;
            var addr = _url + "api/Article/GetPageList?pageIndex={0}";
            addr = string.Format(addr, pageIndex);
            return WebApiHelper.GetEntitys<Article>(addr, ticket);
        }

        public IEnumerable<Article> FindPageListByCategoryId(int? pageIndex, int id)
        {
            var ticket = SaveTicket.Ticket;
            var addr = _url + "api/Article/GetPageListByCategoryId/{0}?pageIndex={1}";
            addr = string.Format(addr, id, pageIndex);
            return WebApiHelper.GetEntitys<Article>(addr, ticket);
        }

        public IEnumerable<Article> FindPageListByAccountId(int? pageIndex, int id)
        {
            var ticket = SaveTicket.Ticket;
            var addr = _url + "api/Article/GetPageListByAccountId/{0}?pageIndex={1}";
            addr = string.Format(addr, id, pageIndex);
            return WebApiHelper.GetEntitys<Article>(addr, ticket);
        }
    }
}
