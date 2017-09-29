using BLL.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.Service.RoleSer
{
    public interface IRoleService
    {
        Role Find(int id);
        Role Find(Expression<Func<Role, bool>> where);

        IQueryable<Role> FindList();

        OperResult Add(Role role);
        OperResult Update(int id);
        OperResult Update(Role role);
        OperResult Update(Expression<Func<Role, bool>> where);
        OperResult Delete(int id);
        OperResult Delete(Role role);
        OperResult Delete(Expression<Func<Role, bool>> where);

    }
}
