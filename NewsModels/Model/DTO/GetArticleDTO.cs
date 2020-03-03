﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsModels.Model.DTO
{
    public class GetArticleDTO
    {
        public int id { get; set; }
        public string teaser { get; set; }
        public string headline { get; set; }
        public string subtitle { get; set; }
        public string byline { get; set; }
        public string lead { get; set; }
        public string content { get; set; }
        public string credit { get; set; }
        public Nullable<int> authorId { get; set; }
        public string AuthorName { get; set; }
        public string leadImage { get; set; }
        public string leadcaption { get; set; }
        public string leadcredit { get; set; }
        //public string Author{ get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<System.DateTime> createddate { get; set; }
    }
}