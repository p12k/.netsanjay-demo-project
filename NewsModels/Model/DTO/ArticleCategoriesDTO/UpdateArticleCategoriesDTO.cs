using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsModels.Model.DTO.ArticleCategoriesDTO
{
    public class UpdateArticleCategoriesDTO
    {

        public int id { get; set; }
        public Nullable<int> authorId { get; set; }
        public Nullable<int> categoryId { get; set; }

        public string ArticleName { get; set; }
        public string CategoryName { get; set; }
    }
}
