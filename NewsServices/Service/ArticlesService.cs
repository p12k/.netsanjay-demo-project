using NewsModels.Model;
using NewsModels.Model.DTO;
using NewsModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsServices.Service
{
    public class ArticlesService : IArticlesService
    {
        private readonly IGenericRepository<Article> _articleRepository;
        //private readonly CreateArticleDTO article;

        public ArticlesService()
        {

            _articleRepository = new GenericRepository<Article>();
        }
        public void DeleteArticle(int id)
        {
            _articleRepository.Delete(id);

        }

        public Author Foreign(Author author)
        {
            throw new NotImplementedException();
        }

        public GetArticleDTO GetArticleById(int id)
        {
            Article article = _articleRepository.GetById(id);
            GetArticleDTO articleDTO = null;
            if (id != 0)
            {
                articleDTO = new GetArticleDTO()
                {

                    teaser = article.teaser,
                    headline = article.headline,
                    subtitle = article.subtitle,
                    byline = article.byline,
                    lead = article.lead,
                    content = article.content,
                    credit = article.credit,
                    authorId = article.authorId,
                    AuthorName = article.Author.name,
                    leadImage = article.leadImage,
                    leadcaption = article.leadcaption,
                    leadcredit = article.leadcredit,
                    date = article.date,
                    createddate = article.createddate,
                };
            }

            return articleDTO;
        }

        public IList<GetArticleDTO> GetArticles()
        {

            IList<Article> articles = _articleRepository.Table.ToList<Article>();
            IList<GetArticleDTO> articleList = new List<GetArticleDTO>();

            foreach (var article in articles)
            {
                GetArticleDTO articleDTO = new GetArticleDTO()
                {
                    id = article.id,
                    teaser = article.teaser,
                    headline = article.headline,
                    subtitle = article.subtitle,
                    byline = article.byline,
                    lead = article.lead,
                    content = article.content,
                    credit = article.credit,
                    authorId = article.authorId,
                    AuthorName = article.Author.name,
                    leadImage = article.leadImage,
                    leadcaption = article.leadcaption,
                    leadcredit = article.leadcredit,
                    date = article.date,
                    createddate = article.createddate
                };
                articleList.Add(articleDTO);
            }


            return articleList;
        }

        public void NewArticle(CreateArticleDTO articleDTO)
        {
            Article article = new Article()
            {
                teaser = articleDTO.teaser,
                headline = articleDTO.headline,
                subtitle = articleDTO.subtitle,
                byline = articleDTO.byline,
                lead = articleDTO.lead,
                content = articleDTO.content,
                credit = articleDTO.credit,
                authorId = articleDTO.authorId,
                leadImage = articleDTO.leadImage,
                leadcaption = articleDTO.leadcaption,
                leadcredit = articleDTO.leadcredit,
                date = articleDTO.date,
                createddate = articleDTO.createddate
            };
            _articleRepository.Insert(article);
        }

        //public void Save(GetArticleDTO articleDTO)
        //{
        //    Article article = new Article()
        //    {
        //        teaser = articleDTO.teaser,
        //        headline = articleDTO.headline,
        //        subtitle = articleDTO.subtitle,
        //        byline = articleDTO.byline,
        //        lead = articleDTO.lead,
        //        content = articleDTO.content,
        //        credit = articleDTO.credit,
        //        authorid = articleDTO.authorid,
        //        leadimage = articleDTO.leadimage,
        //        leadcaption = articleDTO.leadcaption,
        //        leadcredit = articleDTO.leadcredit,
        //        date = articleDTO.date,
        //        createddate = articleDTO.createddate
        //    };
        //    _articleRepository.Save(article);
        //}

        public void UpdateArticle(UpdateArticleDTO articleDTO)
        {
            Article article = new Article()
            {
                id = articleDTO.id,
                teaser = articleDTO.teaser,
                headline = articleDTO.headline,
                subtitle = articleDTO.subtitle,
                byline = articleDTO.byline,
                lead = articleDTO.lead,
                content = articleDTO.content,
                credit = articleDTO.credit,
                authorId = articleDTO.authorid,
                leadImage = articleDTO.leadimage,
                leadcaption = articleDTO.leadcaption,
                leadcredit = articleDTO.leadcredit,
                date = articleDTO.date,
                createddate = articleDTO.createddate
            };
            _articleRepository.Update(article);
        }
    }
}