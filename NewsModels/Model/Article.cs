//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewsModels.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Article
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Article()
        {
            this.ArticleCategories = new HashSet<ArticleCategory>();
            this.ArticleTags = new HashSet<ArticleTag>();
        }
    
        public int id { get; set; }
        public string teaser { get; set; }
        public string headline { get; set; }
        public string subtitle { get; set; }
        public string byline { get; set; }
        public string lead { get; set; }
        public string content { get; set; }
        public string credit { get; set; }
        public Nullable<int> authorId { get; set; }
        public string leadImage { get; set; }
        public string leadcaption { get; set; }
        public string leadcredit { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<System.DateTime> createddate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArticleCategory> ArticleCategories { get; set; }
        public virtual Author Author { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArticleTag> ArticleTags { get; set; }
    }
}
