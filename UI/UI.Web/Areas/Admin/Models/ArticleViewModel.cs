using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Web.Areas.Admin.Models
{
    public class ArticleViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? LastUpdateTime { get; set; }

        public int Stars { get; set; }

        public int ReadNum { get; set; }

        public int CommentNum { get; set; }

        public bool IsPublish { get; set; }

        public bool IsDeleted { get; set; }

        public int UserId { get; set; }

        public int CategoryId { get; set; }
    }
}