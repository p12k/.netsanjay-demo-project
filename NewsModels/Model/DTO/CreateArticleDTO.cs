using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsModels.Model.DTO
{
    public class CreateArticleDTO
    {
        //public int id { get; set; }
        public string teaser { get; set; }

        [Required]
        public string headline { get; set; }

        public string subtitle { get; set; }
        public string byline { get; set; }
        public string lead { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Minimum 5 letters are required!")]
        public string content { get; set; }
        public string credit { get; set; }

        [Required]
        public Nullable<int> authorId { get; set; }
        public string leadImage { get; set; }
        public string leadcaption { get; set; }
        public string leadcredit { get; set; }
        public string Author { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<System.DateTime> createddate { get; set; }
    }
}