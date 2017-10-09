using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Contract;

namespace BLL.Service.Service.RoleSer
{
    public class RoleService : IRoleService
    {
        private string _url;
        public RoleService(string url)
        {
            _url = url;
        }

        public OperResult Add(Role role)
        {
            var ticket = SaveTicket.Ticket;
            var addr = _url + "api/Role/Add";
            return WebApiHelper.PostEntity<Role>(addr, role, ticket);
        }

        public OperResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public OperResult Delete(Role role)
        {
            throw new NotImplementedException();
        }

        public OperResult Delete(Expression<Func<Role, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Role Find(int id)
        {
            throw new NotImplementedException();
        }

        public Role Find(Expression<Func<Role, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> FindList()
        {
            var ticket = SaveTicket.Ticket;
            var addr = _url + "api/Role/GetAllList";
            return WebApiHelper.GetEntitys<Role>(addr, ticket);
        }

        public IQueryable<Role> FindList(Expression<Func<Role, bool>> where)
        {
            throw new NotImplementedException();
        }

        public OperResult Update(int id)
        {
            throw new NotImplementedException();
        }

        public OperResult Update(Role role)
        {
            throw new NotImplementedException();
        }

        public OperResult Update(Expression<Func<Role, bool>> where)
        {
            throw new NotImplementedException();
        }

    }
}
