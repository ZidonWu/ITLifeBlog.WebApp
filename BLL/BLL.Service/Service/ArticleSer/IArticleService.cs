using BLL.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.Service.ArticleSer
{
    public interface IArticleService
    {
        Article Find(int id);
        Article Find(Expression<Func<Article, bool>> where);

        IEnumerable<Article> FindList();
        IEnumerable<Article> FindListByAccountId(string accountId);
        IEnumerable<Article> FindListByAccountName(string accountName);
        IEnumerable<Article> FindList(Expression<Func<Article, bool>> where);

        OperResult Add(Article article);
        OperResult Update(int id);
        OperResult Update(Article article);
        OperResult Update(Expression<Func<Article, bool>> where);
        OperResult Delete(int id, Article article);
        OperResult Delete(Article article);
        OperResult Delete(Expression<Func<Article, bool>> where);

        int Count();
        int CountByAccountName(string accountName);
            
        IEnumerable<Article> FindPageListByCategoryId(int? pageIndex, int id);

        IEnumerable<Article> FindPageListByAccountId(int? pageIndex, int id);   

        IEnumerable<Article> FindPageList(int? pageIndex, string where = "");
    }
}
