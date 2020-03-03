using NewsModels.Model.DTO.ArticleCategoriesDTO;
using System.Collections.Generic;

namespace NewsServices.Service
{
    public interface IArticleCategoriesService
    {
        IList<GetArticleCategoriesDTO> GetArticleCategories();
        GetArticleCategoriesDTO GetArticleCategoriesById(int id);
        void NewArticleCategories(CreateArticleCategoriesDTO article);
        void UpdateArticleCategories(UpdateArticleCategoriesDTO article);
        void DeleteArticleCategories(int id);
    }
}
