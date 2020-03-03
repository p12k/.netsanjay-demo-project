using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsModels.Model.DTO.ArticleCategoriesDTO
{
    public class CreateArticleCategoriesDTO
    {
        //internal int? articleId;

        public Nullable<int> articleId { get; set; }
        public Nullable<int> categoryId { get; set; }

        public virtual Article Article { get; set; }
        public virtual Category Category { get; set; }

    }
}