using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Contract;
using System.Linq.Expressions;

namespace BLL.Service.Service.CategorySer
{
    public class CategoryService : ICategoryService
    {
        private readonly string _url;
        public CategoryService(string url)
        {
            _url = url;
        }

        public OperResult Add(Category category)
        {
            var ticket = SaveTicket.Ticket;
            var addr = _url + "api/Category/Add";
            return WebApiHelper.PostEntity<Category>(addr, category, ticket);
        }

        public IEnumerable<Category> FindList()
        {
            var ticket = SaveTicket.Ticket;
            var addr = _url + "api/Category/GetAllList";
            return WebApiHelper.GetEntitys<Category>(addr, ticket);
        }

        public OperResult Update(int id)
        {
            throw new NotImplementedException();
        }

        public OperResult Update(Category category)
        {
            var ticket = SaveTicket.Ticket;
            var addr = _url + "api/Category/Update";
            return WebApiHelper.PostEntity<Category>(addr, category, ticket);
        }

        public OperResult Update(Expression<Func<Category, bool>> where)
        {
            throw new NotImplementedException();
        }

        public OperResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public OperResult Delete(Category category)
        {
            throw new NotImplementedException();
        }

        public OperResult Delete(Expression<Func<Category, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Category Find(int id)
        {
            var ticket = SaveTicket.Ticket;
            var addr = _url + "api/Category/GetById/{0}";
            addr = string.Format(addr, id);
            return WebApiHelper.GetEntity<Category>(addr, ticket);
        }
    }
}
