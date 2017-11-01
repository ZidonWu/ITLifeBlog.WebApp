using BLL.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Web.Models
{
    public class ListModel
    {
        public IList<Article> ArticleModels { get; set; }   

        public Article Article { get; set; }

        public IList<Article> ArticleModels2 { get; set; }

        public Category Category { get; set; }

        public IList<Category> CategoryModels { get; set; }

        public Account Account { get; set; }

        public IList<Account> AccountModels { get; set; }

        public SearchModel SearchModel { get; set; }


    }
}