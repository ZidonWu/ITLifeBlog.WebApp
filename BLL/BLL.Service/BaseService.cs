using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Contract;
using System.Net;
using System.Linq.Expressions;

namespace BLL.Service
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly string _url;
        public BaseService(string url)
        {
            _url = url;
        }

        private string GetTicket()
        {
            var url = _url + "api/Account/Login?name=admin&password=123";
            return WebApiHelper.GetEntity<Account>(url).Ticket;
        }

        public OperResult Add(T entity)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public OperResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public OperResult Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public OperResult Delete(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public T Find(int id)
        {
            throw new NotImplementedException();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindList()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindList(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public OperResult Update(int id)
        {
            throw new NotImplementedException();
        }

        public OperResult Update(T entity)
        {
            throw new NotImplementedException();
        }

        public OperResult Update(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }
    }
}
