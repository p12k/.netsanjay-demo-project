using NewsModels.Model;
using NewsModels.Model.DTO.ArticleCategoriesDTO;
using NewsModels.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace NewsServices.Service
{
    public class ArticleCategoriesService : IArticleCategoriesService
    {
        private readonly IGenericRepository<ArticleCategory> _articleCategoryRepository;

        public ArticleCategoriesService()
        {

            _articleCategoryRepository = new GenericRepository<ArticleCategory>();
        }
        public void DeleteArticleCategories(int id)
        {
            _articleCategoryRepository.Delete(id);
        }

        public IList<GetArticleCategoriesDTO> GetArticleCategories()
        {
            IList<ArticleCategory> articleCategories = _articleCategoryRepository.Table.ToList<ArticleCategory>();
            IList<GetArticleCategoriesDTO> articleCategoriesList = new List<GetArticleCategoriesDTO>();
            foreach (var articlecategory in articleCategories)
            {
                GetArticleCategoriesDTO articleCategoriesDTO = new GetArticleCategoriesDTO()
                {
                    id = articlecategory.id,
                    articleId = articlecategory.articleId,
                    categoryId = articlecategory.categoryId,
                    ArticleName = articlecategory.Article.teaser,
                    CategoryName = articlecategory.Category.name
                };
                articleCategoriesList.Add(articleCategoriesDTO);
            }
            return articleCategoriesList;
        }

        public GetArticleCategoriesDTO GetArticleCategoriesById(int id)
        {
            ArticleCategory articleCategory = _articleCategoryRepository.GetById(id);
            GetArticleCategoriesDTO articleCategoriesDTO = null;
            if (id != 0)
            {
                articleCategoriesDTO = new GetArticleCategoriesDTO()
                {
                    id = articleCategory.id,
                    articleId = articleCategory.articleId,
                    categoryId = articleCategory.categoryId,
                    ArticleName = articleCategory.Article.teaser,
                    CategoryName = articleCategory.Category.name
                };
            }
            return articleCategoriesDTO;
        }

        public void NewArticleCategories(CreateArticleCategoriesDTO articleCategoryDTO)
        {
            ArticleCategory articleCategory = new ArticleCategory()
            {
                articleId = articleCategoryDTO.articleId,
                categoryId = articleCategoryDTO.categoryId
            };
            _articleCategoryRepository.Insert(articleCategory);
        }

        public void UpdateArticleCategories(UpdateArticleCategoriesDTO articleCategoryDTO)
        {
            ArticleCategory articleCategory = new ArticleCategory()
            {
                id = articleCategoryDTO.id,
                articleId = articleCategoryDTO.id,
                categoryId = articleCategoryDTO.categoryId
            };
            _articleCategoryRepository.Update(articleCategory);
        }
    }
}