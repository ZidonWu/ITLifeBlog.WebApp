using BLL.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.Service.CategorySer
{
    public interface ICategoryService
    {
        IEnumerable<Category> FindList();

        OperResult Add(Category category);
        
        OperResult Update(int id);
        
        OperResult Update(Category category);
        
        OperResult Update(Expression<Func<Category,bool>> where);
        
        OperResult Delete(int id);
        
        OperResult Delete(Category category);
        
        OperResult Delete(Expression<Func<Category,bool>> where);
    }
}
