using BLL.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public interface IBaseService<T> where T : class
    {
        T Find(int id);
        T Find(Expression<Func<T, bool>> where);

        IQueryable<T> FindList();
        IQueryable<T> FindList(Expression<Func<T, bool>> where);

        OperResult Add(T entity);
        OperResult Update(int id);
        OperResult Update(T entity);
        OperResult Update(Expression<Func<T, bool>> where);
        OperResult Delete(int id);
        OperResult Delete(T entity);
        OperResult Delete(Expression<Func<T, bool>> where);

        int Count();
        int Count(Expression<Func<T, bool>> where);
    }
}
