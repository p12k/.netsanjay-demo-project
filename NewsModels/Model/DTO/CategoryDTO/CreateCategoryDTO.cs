using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsModels.Model.DTO.CategoryDTO
{
    public class CreateCategoryDTO
    {

        public string name { get; set; }
        public string displayname { get; set; }
        public Nullable<bool> isDeleted { get; set; }

    }
}