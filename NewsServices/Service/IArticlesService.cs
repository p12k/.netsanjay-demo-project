using NewsModels.Model.DTO;
using System.Collections.Generic;

namespace NewsServices.Service
{
    public interface IArticlesService
    {
        IList<GetArticleDTO> GetArticles();
        GetArticleDTO GetArticleById(int id);
        void NewArticle(CreateArticleDTO article);
        void UpdateArticle(UpdateArticleDTO article);
        void DeleteArticle(int id);
        //void Save(GetArticleDTO article);
    }
}
